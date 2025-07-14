using System.Collections.Generic;
using UnityEngine;

public class FractalGenerator : MonoBehaviour
{
    public Fractal fractalToGenerate;
    public int maxDepth = 5;
    public List<List<GameObject>> fractalsByDepth = new List<List<GameObject>>();

    void Start()
    {
        fractalsByDepth.Add(new List<GameObject>());
        fractalsByDepth[0].Add(fractalToGenerate.model);
    }

    public void ReproduceFractal(GameObject currFractalModel)
    {

        for (int i = 0; i < fractalToGenerate.childrenTransforms.Count; i++)
        {
            GameObject newFractalModel = Instantiate(currFractalModel);

            Transform childTransform = fractalToGenerate.childrenTransforms[i];

            //Vector3 position = currFractalModel.transform.position;
            //position.x = childTransform.localPosition.x * currFractalModel.transform.localScale.x + currFractalModel.transform.position.x;
            //position.y = childTransform.localPosition.y * currFractalModel.transform.localScale.y + currFractalModel.transform.position.y;
            //position.z = childTransform.localPosition.z * currFractalModel.transform.localScale.z + currFractalModel.transform.position.z;
            //newFractalModel.transform.position = position;

            newFractalModel.transform.Translate(childTransform.localPosition * currFractalModel.transform.localScale.x);
            newFractalModel.transform.Rotate(childTransform.localRotation.eulerAngles);

            Vector3 scale = currFractalModel.transform.localScale;
            scale.x *= childTransform.localScale.x;
            scale.y *= childTransform.localScale.y;
            scale.z *= childTransform.localScale.z;
            newFractalModel.transform.localScale = scale;

            newFractalModel.transform.SetParent(transform);
            fractalsByDepth[fractalsByDepth.Count - 1].Add(newFractalModel);
        }
    }

    public void GenerateFractal()
    {
        fractalsByDepth.Add(new List<GameObject>());
        int numberOfFractalsToGenerate = fractalsByDepth[fractalsByDepth.Count - 2].Count;
        print("Number of fractals to generate: " + numberOfFractalsToGenerate);
        for (int currFractalModel = 0; currFractalModel < numberOfFractalsToGenerate; currFractalModel++)
        {
            ReproduceFractal(fractalsByDepth[fractalsByDepth.Count - 2][currFractalModel]);
        }
    }


    public void ResetFractal()
    {
        for (int i = 0; i < fractalsByDepth.Count; i++)
        {
            foreach (GameObject fractal in fractalsByDepth[i])
            {
                if (fractal == fractalToGenerate.model)
                {
                    continue; // Skip the first depth as it contains the original model
                }
                Destroy(fractal);
            }
        }
        fractalsByDepth.Clear();
        fractalsByDepth.Add(new List<GameObject>());
        fractalsByDepth[0].Add(fractalToGenerate.model);
    }
}
