using UnityEngine;



public abstract class Screen : MonoBehaviour
{
	public class ScreenData
	{
		
	}

	protected ScreenData _data;

	public virtual void SetData(ScreenData data)
	{
		_data = data;
	}

	public ScreenData GetData()
	{
		return _data;
	}
}
