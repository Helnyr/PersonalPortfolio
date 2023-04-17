using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomName : MonoBehaviour
{
    public string[] names = {
        "Balthazar McSquiggles",
        "Ethelbert Puddlesworth",
        "Bartholomew Beanbag",
        "Gertrude Wobblebottom",
        "Archibald Wigglesworth",
        "Hortense Crumplehorn",
        "Reginald Muffintop",
        "Muriel McFluffernutter",
        "Percival Bumbleberry",
        "Dorothea Snickerdoodle",
        "Mortimer Whippersnapper",
        "Prudence Flapjacks",
        "Algernon Snugglesworth",
        "Wilhelmina Bumbershoot",
        "Egbert Fizzywig",
        "Binky McSquishyface",
        "Ethelreda Snorklebottom",
        "Barnabas Flapjack",
        "Gertrude Bumpersnoot",
        "Archimedes Fizzlesprocket",
        "Hortense Wibblewobble",
        "Reginald Bumblebee",
        "Muriel McSprinkles",
        "Percival Crumpet",
        "Dorothea Fizzgiggle",
        "Mortimer Puddingpop",
        "Prudence Buttercup",
        "Algernon Wobblewhiskers",
        "Wilhelmina Noodlehead",
        "Egbert Wigglesnout",
    };

    public string GenerateRandomName()
    {
        int randomIndex = Random.Range(0, names.Length);
        return names[randomIndex];
    }
}
