using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class R_GameManager : MonoBehaviour
{
    readonly string[] COLOR_NAMES = { "Red", "Blue", "Green", "Yellow" };
    Dictionary<string, Color> colors = new Dictionary<string, Color>();

    public int Score { get; set; } = 0;

    [SerializeField] GameObject buttons_parent;
    [SerializeField] MeshRenderer[] show_color_boxes;

    List<string> random_colors = new List<string>();
    List<string> choose_colors = new List<string>();
    int cur_index = 0;

    void Start()
    {
        colors["Red"] = Color.red;
        colors["Blue"] = Color.blue;
        colors["Green"] = Color.green;
        colors["Yellow"] = Color.yellow;


        SelectColor();
    }

    void Update()
    {

    }

    void SelectColor()
    {
        int r = Random.Range(0, 4);

        random_colors.Add(COLOR_NAMES[r]);

        StartCoroutine(ShowColors());
    }

    IEnumerator ShowColors()
    {
        buttons_parent.SetActive(false);

        for (int i = 0; i < random_colors.Count; i++)
        {
            foreach (var box in show_color_boxes)
            {
                box.material.color = colors[random_colors[i]];
            }

            yield return new WaitForSeconds(1);
        }

        foreach (var box in show_color_boxes)
        {
            box.material.color = Color.white;
        }

        buttons_parent.SetActive(true);
    }

    public void ButtonClick(int color)
    {
        Debug.Log(color);

        if (color > 3)
        {
            Debug.LogError("Other color case");
            return;
        }

        choose_colors.Add(COLOR_NAMES[color]);

        if (random_colors[cur_index] == choose_colors[cur_index])
        {
            if (cur_index >= random_colors.Count - 1) // 끝까지 다 맞췄을 때
            {
                cur_index = 0;
                choose_colors.Clear();

                Score++;
            }
            else
            {
                cur_index++;
            }
        }
        else
        {
            choose_colors.RemoveAt(cur_index);
            return;
        }

        SelectColor();
    }
}
