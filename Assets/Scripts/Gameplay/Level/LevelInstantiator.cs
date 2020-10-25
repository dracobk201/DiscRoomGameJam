using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class LevelInstantiator : MonoBehaviour
{
    [SerializeField] private List<InstatiationPoint> instatiationPoints = null;
    [SerializeField] private GameEvent cleanProps = null;
    [SerializeField] private GameEvent loadLevelCompleted = null;
    [SerializeField] private PropsSO props = null;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R)){
            StartInstantiating();
        }
    }

    [ContextMenu("StartInstantiating")]
    public void StartInstantiating()
    {
        cleanProps.Raise();
        var numberOfAssets = Random.Range(0, props.props.Count);
        var propsSorted = props.props.OrderBy(a => GUID.Generate()).ToList();
        instantiateProps(propsSorted.GetRange(0, numberOfAssets));
        loadLevelCompleted.Raise();
    }

    public void instantiateProps(List<PropSO> props)
    {
        foreach (var item in props)
        {
            var viableInstantiationPoints = instatiationPoints.FindAll(x => x.propType == item.propType);
            viableInstantiationPoints = viableInstantiationPoints.OrderBy(a => GUID.Generate()).ToList();
            for (int i = 0; i < viableInstantiationPoints.Count; i++)
            {
                var aux = viableInstantiationPoints[i];
                if (aux.used == false)
                {
                    aux.used = true;
                    aux.AddObject(item);
                    i = int.MaxValue - 1;
                }
            }
        }
    }

    [ContextMenu("Find Instantiation Points")]
    public void FindAllObject()
    {
        instatiationPoints.Clear();
        allChildren(this.transform);
    }

    private void allChildren(Transform currentTransform)
    {
        foreach (Transform child in this.transform)
        {
            if (TryGetComponent(out InstatiationPoint ip))
            {
                instatiationPoints.Add(ip);
            }
        }
    }
}
