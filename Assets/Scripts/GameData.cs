using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace Desolation
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData")]
    public class GameData : ScriptableObject
    {
        [SerializeField, DontCreateProperty] private float cameraViewPixelBlockSize;
        public float CameraViewPixelBlockSize => cameraViewPixelBlockSize;
        
        public Vector4 CameraViewPixelation {private get; set; }
        [CreateProperty] public StyleMaterialDefinition PixelationMaterial
        {
            get
            {
                var def = new MaterialDefinition();
                var shader = R.PixelationUIShader;
                def.material = new Material(shader);
                def.SetVector("_PixelSize", CameraViewPixelation);
                
                var style = new StyleMaterialDefinition(def);
                return style;
            }
        }
    }
}