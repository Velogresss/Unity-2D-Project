using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}
/* [SerializeField] - атрибут, що зазначає те, що значення для поля
 * буде визначено через "Редактор".
 * Translate - переміщення
 * Time.deltaTime - час, що пройшов від попереднього фрейму (виклику методу)
 * корекція на час (множення на Time.deltaTime) створює FPS-незалежність
 * FPS     Translate(без dT)     Translate(з dT)
 * 100        100 x 1            100 x 1/100 x 1
 * 50          50 x 1            50 x 1/50 x 1
 * 
 */
