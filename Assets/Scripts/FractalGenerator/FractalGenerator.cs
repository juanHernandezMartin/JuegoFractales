using System.Collections.Generic;
using UnityEngine;

public class FractalGenerator : MonoBehaviour
{
    public Fractal fractalToGenerate;
    public int maxDepth = 5;
    public List<List<GameObject>> fractalsByDepth = new();

    public List<float> scaleFactors = new();
    public List<float> rotationFactors = new();
    public List<Vector3> positionFactors = new();

    private bool isInitialized = false;

    void Start()
    {
        fractalsByDepth.Add(new List<GameObject>());
        fractalsByDepth[0].Add(fractalToGenerate.model);

    }

    public void ReproduceFractal(GameObject currFractalModel)
    {
        currFractalModel.GetComponent<FractalScriptDisabler>().EnableFractalScripts();

        for (int i = 0; i < fractalToGenerate.childrenTransforms.Count; i++)
        {
            GameObject newFractalModel = Instantiate(currFractalModel);

            // --- 1) Posición desplazada como antes:
            float currScale = currFractalModel.transform.localScale.x;
            float originalScale = fractalToGenerate.model.transform.localScale.x;
            float offsetMult = currScale / originalScale;
            newFractalModel.transform.Translate(positionFactors[i] * offsetMult);

            // --- 2) Rotación alrededor del handlerJoiner:
            var pivot = newFractalModel
                .GetComponent<RefenceToHandlerJoiner>()
                .handlerJoiner.position;
            newFractalModel.transform.RotateAround(pivot, Vector3.forward, rotationFactors[i]);

            // --- 3) Escalado alrededor del mismo pivote:
            //   a) guardamos la posición mundial previa al escalado
            Vector3 worldPosBefore = newFractalModel.transform.position;
            //   b) aplicamos la escala (relativa al Transform padre)
            newFractalModel.transform.localScale *= scaleFactors[i];
            //   c) reposicionamos para que el escalado gire “hacia afuera” desde el pivote
            newFractalModel.transform.position =
                pivot + (worldPosBefore - pivot) * scaleFactors[i];

            // --- 4) parenting y almacenamiento
            newFractalModel.transform.SetParent(transform);
            fractalsByDepth[fractalsByDepth.Count - 1].Add(newFractalModel);

            newFractalModel.GetComponent<FractalScriptDisabler>().DisableFractalScripts();
        }

        currFractalModel.GetComponent<FractalScriptDisabler>().DisableFractalScripts();
    }

    public void GenerateFractal()
    {
        if (!isInitialized)
        {
            InitiazeFactors();
            isInitialized = true;
        }

        fractalToGenerate.model.GetComponent<FractalScriptDisabler>().EnableFractalScripts();

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

        isInitialized = false;
        scaleFactors.Clear();
        rotationFactors.Clear();
        positionFactors.Clear();
    }


    public void InitiazeFactors()
    {
        Vector3 fatherPosition = fractalToGenerate.model.GetComponent<RefenceToHandlerJoiner>().handlerJoiner.position;
        float fatherRotation = fractalToGenerate.model.GetComponent<RefenceToHandlerJoiner>().handlerJoiner.localRotation.eulerAngles.z;
        float fatherScale = fractalToGenerate.model.GetComponent<RefenceToHandlerJoiner>().handlerJoiner.localScale.x;


        for (int i = 0; i < fractalToGenerate.childrenTransforms.Count; i++)
        {
            Transform childTransform = fractalToGenerate.childrenTransforms[i];

            Vector3 localChildPosition = childTransform.position;
            Vector3 positionFactor = new Vector3(
                localChildPosition.x - fatherPosition.x,
                localChildPosition.y - fatherPosition.y,
                localChildPosition.z - fatherPosition.z
            );
            positionFactors.Add(positionFactor);


            float localRotationChild = childTransform.localRotation.eulerAngles.z;
            float rotationFactor = localRotationChild - fatherRotation;
            rotationFactors.Add(rotationFactor);

            float localScaleChild = childTransform.localScale.x;
            float scaleFactor = localScaleChild / fatherScale;
            scaleFactors.Add(scaleFactor);
        }
    }
}
