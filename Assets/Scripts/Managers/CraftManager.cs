using PotionCraft.Enum;
using PotionCraft.InventoryScripts;
using PotionCraft.ItemScripts;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PotionCraft.Managers
{
    public class CraftManager : MonoBehaviour
    {
    
		public ClientData currentClient;
		public TextMeshProUGUI debugResultText;
		public TextMeshProUGUI clientNameText;
		public TextMeshProUGUI clientProblemText;
        #region Fields
        public List<GameObject> _ingredientsList = new List<GameObject>();

        [SerializeField] private Inventory _inventory;
        [SerializeField] private InventoryUI _inventoryUI;

        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private Transform _canvasTransform;
        [SerializeField] private Transform _runtimeItemsParent;
        [SerializeField] private RectTransform _button;
		[SerializeField] private RectTransform _cauldron;
		[SerializeField] private RectTransform _menuPanel;


		public void Start(){
			clientNameText.text = currentClient.name;
			clientProblemText.text = currentClient.requestText;
        }
        #endregion

        #region Methods

        private void OnCollisionEnter2D(Collision2D collision){
        
		    int rand = Random.Range(0, 10);
	        if (collision.gameObject.GetComponent<ItemUI>().Item.ItemType == ItemType.Ingredient)
	        {
	            _ingredientsList.Add(collision.gameObject);
	            collision.gameObject.SetActive(false);
	        }
	        else{
	            int randomDirection = Random.Range(0, rand);
	            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(
	            	new Vector2(randomDirection == 0 ? Random.Range(-2f, -4f) : Random.Range(2f, 4f), 13), ForceMode2D.Impulse);
	        }
		}

        public void CraftPotion()
        {
        	_ingredientsList.ForEach(obj => Debug.Log(obj.gameObject.GetComponent<ItemUI>().Item.Title));
        	if (_ingredientsList.Count>1){
		    	int rand = Random.Range(0, 10);
				float love = 0f;
				float chaos = 0f;
				float stability = 0f;
				float amplifier = 0f;
				
				foreach (GameObject ingredient in _ingredientsList){
					Item item = ingredient.gameObject.GetComponent<ItemUI>().Item;
					
					if (Random.Range(0, 100) <= item.EffectProbability){
		            	love += item.Love;
		            	chaos += item.Chaos;
		            	stability += item.Stability;
		            	amplifier += item.Amplifier;
		        	}
		        	
				}
				
		        Item craftedPotion = new Item(
		              ItemType.Potion,
		              love,
		              chaos,
		              stability,
		              amplifier);
				float baseScore = love + stability - chaos;
				float random = Random.Range(-5f, 10f);
				float total = baseScore + random;

				if (currentClient != null)
				{
				    if (chaos > currentClient.chaosTolerance)
				    {
				        float extraChaos = chaos - currentClient.chaosTolerance;
				        total -= extraChaos * 0.5f;
				    }

				    float loveDiff = Mathf.Abs(love - currentClient.desiredLove);
				    float stabilityDiff = Mathf.Abs(stability - currentClient.desiredStability);
				    total -= (loveDiff + stabilityDiff) * 0.2f;
				}

				float perfectThreshold = 90f;
				float goodThreshold = 60f;
				float weirdThreshold = 30f;

				if (currentClient != null)
				{
				    perfectThreshold = currentClient.perfectThreshold;
				    goodThreshold = currentClient.goodThreshold;
				    weirdThreshold = currentClient.weirdThreshold;
				}
				
				BrewOutcome outcome;

				if (total >= perfectThreshold) outcome = BrewOutcome.Perfect;
				else if (total >= goodThreshold) outcome = BrewOutcome.Good;
				else if (total >= weirdThreshold) outcome = BrewOutcome.Weird;
				else outcome = BrewOutcome.Disaster;
				if (debugResultText != null)
		        debugResultText.text = $"{outcome} ({Mathf.RoundToInt(total)})";
		        _inventory.AddItemToInventory(craftedPotion);

		        foreach (GameObject ingredient in _ingredientsList)
		        {
		            Destroy(ingredient);
		        }

		        _ingredientsList.Clear();

		        CreatePotionGO(craftedPotion);
		        FixUILayerOrder();

		    }else if (_ingredientsList.Count == 1){
		    	Debug.Log("One Ingridient");
		    	Item res = _ingredientsList[0].gameObject.GetComponent<ItemUI>().Item;
		    	_inventory.AddItemToInventory(res);
		        Destroy(_ingredientsList[0]);
		        _ingredientsList.Clear();
		        CreatePotionGO(res, true);
		        FixUILayerOrder();
		    }
        }

        private void CreatePotionGO(Item item, bool isIngridient=false)
        {
			GameObject go = Instantiate(_itemPrefab, _runtimeItemsParent);

			go.transform.position = transform.position;
			go.transform.localScale = Vector3.one * 3f;

			go.GetComponent<ItemUI>().UpdateItem(item, isIngridient);
			go.GetComponent<Rigidbody2D>().simulated = true;

			if (isIngridient)
			{
				int randomDirection = Random.Range(0, 8);
				go.GetComponent<Rigidbody2D>().AddForce(
				    new Vector2(
				        randomDirection == 0 ? Random.Range(-2f, -4f) : Random.Range(2f, 4f),
				        13),
				    ForceMode2D.Impulse);
    		}
    		FixUILayerOrder();
        }
        
        private void FixUILayerOrder()
		{
			_cauldron.SetAsLastSibling();
			_button.SetAsLastSibling();// temporarily last
			_menuPanel.SetAsLastSibling();  // true last
		}
    }

    #endregion
}