using System.Collections.Generic;
using Unity.Simulation;
using UnityEngine;

public class ApplySegmentation : MonoBehaviour
{

    public Shader segmentShader;
    public Camera segmentCamera;

    Dictionary<string, Color32> segmentDict = new Dictionary<string, Color32>();

    Dictionary<string, Color32> segmentDictStructure = new Dictionary<string, Color32>();

    void Start()
    {
        Debug.Log(Application.persistentDataPath + "/" + Configuration.Instance.GetAttemptId());

        // Fill the Dictionary with Tag names and corresponding colors
        segmentDict.Add("ScrubBrush", new Color32(222, 148, 80, 255));
        segmentDict.Add("CoffeeMachine", new Color32(147, 71, 238, 255));
        segmentDict.Add("RemoteControl", new Color32(187, 19, 208, 255));
        segmentDict.Add("TissueBox", new Color32(98, 43, 249, 255));
        segmentDict.Add("DishSponge", new Color32(166, 58, 136, 255));
        segmentDict.Add("SideTable", new Color32(202, 45, 114, 255));
        segmentDict.Add("CounterTop", new Color32(103, 209, 30, 255));
        segmentDict.Add("Spoon", new Color32(235, 57, 90, 255));
        segmentDict.Add("CoffeeTable", new Color32(18, 14, 75, 255));
        segmentDict.Add("Bed", new Color32(209, 156, 101, 255));
        segmentDict.Add("VacuumCleaner", new Color32(230, 13, 166, 255));
        segmentDict.Add("Window", new Color32(200, 150, 134, 255));
        segmentDict.Add("Watch", new Color32(242, 6, 88, 255));
        segmentDict.Add("GarbageBag", new Color32(250, 186, 207, 255));
        segmentDict.Add("PaperTowelRoll", new Color32(144, 173, 28, 255));
        segmentDict.Add("TowelHolder", new Color32(232, 28, 225, 255));
        segmentDict.Add("Television", new Color32(27, 245, 217, 255));
        segmentDict.Add("Sofa", new Color32(82, 143, 39, 255));
        segmentDict.Add("SoapBottle", new Color32(168, 222, 137, 255));
        segmentDict.Add("Boots", new Color32(121, 126, 101, 255));
        segmentDict.Add("SaltShaker", new Color32(36, 222, 26, 255));
        segmentDict.Add("ArmChair", new Color32(96, 52, 68, 255));
        segmentDict.Add("Desk", new Color32(14, 120, 179, 255));
        segmentDict.Add("Pot", new Color32(132, 237, 87, 255));
        segmentDict.Add("Tomato", new Color32(119, 189, 121, 255));
        segmentDict.Add("LightSwitch", new Color32(11, 51, 121, 255));
        segmentDict.Add("Curtains", new Color32(6, 62, 102, 255));
        segmentDict.Add("DeskLamp", new Color32(99, 164, 25, 255));
        segmentDict.Add("Lettuce", new Color32(203, 156, 88, 255));
        segmentDict.Add("Pan", new Color32(246, 212, 161, 255));
        segmentDict.Add("RoomDecor", new Color32(216, 96, 246, 255));
        segmentDict.Add("CellPhone", new Color32(227, 98, 136, 255));
        segmentDict.Add("Floor", new Color32(243, 246, 208, 255));
        segmentDict.Add("BaseballBat", new Color32(171, 20, 38, 255));
        segmentDict.Add("Dumbbell", new Color32(45, 57, 144, 255));
        segmentDict.Add("Cup", new Color32(35, 71, 130, 255));
        segmentDict.Add("ToiletPaper", new Color32(162, 204, 152, 255));
        segmentDict.Add("SinkBasin", new Color32(80, 192, 81, 255));
        segmentDict.Add("ShowerGlass", new Color32(80, 68, 237, 255));
        segmentDict.Add("Fork", new Color32(54, 200, 25, 255));
        segmentDict.Add("SprayBottle", new Color32(89, 126, 121, 255));
        segmentDict.Add("TeddyBear", new Color32(229, 73, 134, 255));
        segmentDict.Add("StoveBurner", new Color32(156, 249, 101, 255));
        segmentDict.Add("FloorLamp", new Color32(253, 73, 35, 255));
        segmentDict.Add("Stool", new Color32(13, 54, 156, 255));
        segmentDict.Add("Potato", new Color32(187, 142, 9, 255));
        segmentDict.Add("Toaster", new Color32(55, 33, 114, 255));
        segmentDict.Add("Ottoman", new Color32(160, 135, 174, 255));
        segmentDict.Add("HandTowel", new Color32(182, 187, 236, 255));
        segmentDict.Add("Bottle", new Color32(64, 80, 115, 255));
        segmentDict.Add("HandTowelHolder", new Color32(58, 218, 247, 255));
        segmentDict.Add("Laptop", new Color32(20, 107, 222, 255));
        segmentDict.Add("Kettle", new Color32(7, 83, 48, 255));
        segmentDict.Add("Pillow", new Color32(217, 193, 130, 255));
        segmentDict.Add("Candle", new Color32(233, 102, 178, 255));
        segmentDict.Add("ShelvingUnit", new Color32(125, 226, 119, 255));
        segmentDict.Add("Shelf", new Color32(39, 54, 158, 255));
        segmentDict.Add("DogBed", new Color32(106, 193, 45, 255));
        segmentDict.Add("Ladle", new Color32(174, 98, 216, 255));
        segmentDict.Add("Faucet", new Color32(21, 38, 98, 255));
        segmentDict.Add("ButterKnife", new Color32(135, 147, 55, 255));
        segmentDict.Add("Knife", new Color32(211, 157, 122, 255));
        segmentDict.Add("Dresser", new Color32(51, 128, 146, 255));
        segmentDict.Add("AluminumFoil", new Color32(181, 163, 89, 255));
        segmentDict.Add("Poster", new Color32(145, 87, 153, 255));
        segmentDict.Add("Pen", new Color32(239, 130, 152, 255));
        segmentDict.Add("TennisRacket", new Color32(138, 71, 107, 255));
        segmentDict.Add("Towel", new Color32(170, 186, 210, 255));
        segmentDict.Add("Newspaper", new Color32(19, 196, 2, 255));
        segmentDict.Add("ShowerHead", new Color32(248, 167, 29, 255));
        segmentDict.Add("Bowl", new Color32(209, 182, 193, 255));
        segmentDict.Add("Pencil", new Color32(177, 226, 23, 255));
        segmentDict.Add("Blinds", new Color32(214, 223, 197, 255));
        segmentDict.Add("Footstool", new Color32(74, 187, 51, 255));
        segmentDict.Add("ShowerCurtain", new Color32(60, 12, 39, 255));
        segmentDict.Add("TVStand", new Color32(94, 234, 136, 255));
        segmentDict.Add("Plate", new Color32(188, 154, 128, 255));
        segmentDict.Add("Drawer", new Color32(155, 30, 210, 255));
        segmentDict.Add("GarbageCan", new Color32(225, 40, 55, 255));
        segmentDict.Add("Mirror", new Color32(36, 3, 222, 255));
        segmentDict.Add("Book", new Color32(43, 31, 148, 255));
        segmentDict.Add("BathtubBasin", new Color32(109, 206, 121, 255));
        segmentDict.Add("Plunger", new Color32(74, 209, 56, 255));
        segmentDict.Add("AlarmClock", new Color32(184, 20, 170, 255));
        segmentDict.Add("Vase", new Color32(83, 152, 69, 255));
        segmentDict.Add("SoapBar", new Color32(43, 97, 155, 255));
        segmentDict.Add("Chair", new Color32(166, 13, 176, 255));
        segmentDict.Add("BasketBall", new Color32(97, 58, 36, 255));
        segmentDict.Add("LaundryHamper", new Color32(35, 109, 26, 255));
        segmentDict.Add("Toilet", new Color32(21, 27, 163, 255));
        segmentDict.Add("Sink", new Color32(30, 181, 88, 255));
        segmentDict.Add("KeyChain", new Color32(27, 54, 18, 255));
        segmentDict.Add("Microwave", new Color32(54, 96, 202, 255));
        segmentDict.Add("Bathtub", new Color32(59, 170, 176, 255));
        segmentDict.Add("ToiletPaperHanger", new Color32(124, 32, 10, 255));
        segmentDict.Add("Box", new Color32(60, 252, 230, 255));
        segmentDict.Add("Egg", new Color32(240, 75, 163, 255));
        segmentDict.Add("Cloth", new Color32(110, 184, 56, 255));
        segmentDict.Add("TableTopDecor", new Color32(126, 204, 158, 255));
        segmentDict.Add("Cabinet", new Color32(210, 149, 89, 255));
        segmentDict.Add("DiningTable", new Color32(83, 33, 33, 255));
        segmentDict.Add("Fridge", new Color32(91, 156, 207, 255));
        segmentDict.Add("Apple", new Color32(159, 98, 144, 255));
        segmentDict.Add("WateringCan", new Color32(147, 67, 249, 255));
        segmentDict.Add("CD", new Color32(65, 112, 172, 255));
        segmentDict.Add("Mug", new Color32(8, 94, 186, 255));
        segmentDict.Add("StoveKnob", new Color32(106, 252, 95, 255));
        segmentDict.Add("CreditCard", new Color32(56, 235, 12, 255));
        segmentDict.Add("Desktop", new Color32(35, 16, 64, 255));
        segmentDict.Add("Safe", new Color32(198, 238, 160, 255));
        segmentDict.Add("PepperShaker", new Color32(5, 204, 214, 255));
        segmentDict.Add("Spatula", new Color32(30, 98, 242, 255));
        segmentDict.Add("ShowerDoor", new Color32(36, 253, 61, 255));
        segmentDict.Add("HousePlant", new Color32(73, 144, 213, 255));
        segmentDict.Add("WineBottle", new Color32(53, 130, 252, 255));
        segmentDict.Add("Statue", new Color32(243, 75, 41, 255));
        segmentDict.Add("Bread", new Color32(18, 150, 252, 255));
        segmentDict.Add("Painting", new Color32(40, 117, 236, 255));

        segmentDictStructure.Add("wallpanel", new Color32(56, 128, 14, 255));
        segmentDictStructure.Add("Wall", new Color32(245, 17, 128, 255));
        segmentDictStructure.Add("Floor", new Color32(243, 246, 208, 255));
        segmentDictStructure.Add("Vent", new Color32(57, 57, 118, 255));
        segmentDictStructure.Add("Ceiling", new Color32(25, 25, 255, 255));


        // Find all GameObjects with Mesh Renderer and add a color variable to be
        // used by the shader in it's MaterialPropertyBlock
        var mpb = new MaterialPropertyBlock();
        GameObject[] simObjPhysics = GameObject.FindGameObjectsWithTag("SimObjPhysics");
        GameObject[] structure = GameObject.FindGameObjectsWithTag("Structure");

        foreach (GameObject go in simObjPhysics)
        {
            string[] name = go.name.Split('_');
            if (name.Length >= 1)
            {
                // SIDETABLE
                if (name[0] == "SideTable")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                        else
                        {
                            string[] childName = child.name.Split('_');
                            if (childName.Length >= 1)
                            {
                                foreach (Transform child2 in child.transform)
                                {
                                    string[] child2Name = child2.name.Split('_');
                                    MeshRenderer child2MR = child2.GetComponent<MeshRenderer>();
                                    if (child2MR != null && childName[0] == "Shelf")
                                    {
                                        segmentDict.TryGetValue(childName[0], out Color32 outColorChild);
                                        mpb.SetColor("_SegmentColor", outColorChild);
                                        child2MR.SetPropertyBlock(mpb);
                                    }
                                    if (child2MR != null && childName[0] == "Drawer")
                                    {
                                        segmentDict.TryGetValue(childName[0], out Color32 outColorChild);
                                        mpb.SetColor("_SegmentColor", outColorChild);
                                        child2MR.SetPropertyBlock(mpb);
                                    }
                                }
                            }
                        }
                    }
                }

                // TVStand
                if (name[0] == "TVStand")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                        else
                        {
                            string[] childName = child.name.Split('_');
                            if (childName.Length >= 1)
                            {
                                foreach (Transform child2 in child.transform)
                                {
                                    string[] child2Name = child2.name.Split('_');
                                    MeshRenderer child2MR = child2.GetComponent<MeshRenderer>();
                                    if (child2MR != null && childName[0] == "Shelf")
                                    {
                                        segmentDict.TryGetValue(childName[0], out Color32 outColorChild);
                                        mpb.SetColor("_SegmentColor", outColorChild);
                                        child2MR.SetPropertyBlock(mpb);
                                    }
                                }
                            }
                        }
                    }
                }

                // Book
                if (name[0] == "Book")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                        else
                        {
                            string[] childName = child.name.Split('_');
                            if (childName.Length >= 1)
                            {
                                foreach (Transform child2 in child.transform)
                                {
                                    string[] child2Name = child2.name.Split('_');
                                    MeshRenderer child2MR = child2.GetComponent<MeshRenderer>();
                                    if (child2MR != null && childName[0] == "book")
                                    {
                                        childName[0] = "Book";
                                        segmentDict.TryGetValue(childName[0], out Color32 outColorChild);
                                        mpb.SetColor("_SegmentColor", outColorChild);
                                        child2MR.SetPropertyBlock(mpb);
                                    }
                                }
                            }
                        }
                    }
                }

                // Pot
                if (name[0] == "Pot")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // Apple
                if (name[0] == "Apple")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // Pillow
                if (name[0] == "pillow")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            name[0] = "Pillow";
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // BaseballBat
                if (name[0] == "BaseballBat")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // Basketball
                if (name[0] == "Basketball")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            name[0] = "BasketBall";
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // Bottle
                if (name[0] == "Bottle")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            mr.material.SetOverrideTag("RenderType", "");
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // Bowl
                if (name[0] == "Bowl")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // Bin
                if (name[0] == "bin" || name[0] == "Bin")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            name[0] = "GarbageCan";
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // HousePlant
                if (name[0] == "Houseplant")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            name[0] = "HousePlant";
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // LapTop
                if (name[0] == "Laptop")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                        else
                        {
                            string[] childName = child.name.Split('_');
                            if (childName.Length >= 1)
                            {
                                foreach (Transform child2 in child.transform)
                                {
                                    string[] child2Name = child2.name.Split('_');
                                    MeshRenderer child2MR = child2.GetComponent<MeshRenderer>();
                                    if (child2MR != null && child2Name[0] == "lid")
                                    {
                                        childName[0] = "Laptop";
                                        segmentDict.TryGetValue(childName[0], out Color32 outColorChild);
                                        mpb.SetColor("_SegmentColor", outColorChild);
                                        child2MR.SetPropertyBlock(mpb);
                                    }
                                }
                            }
                        }
                    }
                }

                // Mug
                if (name[0] == "Mug")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // Remote
                if (name[0] == "Remote")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            name[0] = "RemoteControl";
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                        foreach (Transform child2 in child.transform)
                        {
                            // MR
                            MeshRenderer mr2 = child2.GetComponent<MeshRenderer>();
                            if (mr2 != null)
                            {
                                segmentDict.TryGetValue("RemoteControl", out Color32 outColor);
                                mpb.SetColor("_SegmentColor", outColor);
                                mr2.SetPropertyBlock(mpb);
                            }
                        }
                    }
                }

                // Television
                if (name[0] == "Television")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            name[0] = "Television";
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }

                        foreach (Transform child2 in child.transform)
                        {
                            // MR
                            MeshRenderer mr2 = child2.GetComponent<MeshRenderer>();
                            if (mr2 != null)
                            {
                                segmentDict.TryGetValue("Television", out Color32 outColor);
                                mpb.SetColor("_SegmentColor", outColor);
                                mr2.SetPropertyBlock(mpb);
                            }
                        }
                    }
                }

                // Box
                if (name[0] == "Box")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            name[0] = "Box";
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }

                        foreach (Transform child2 in child.transform)
                        {
                            // MR
                            MeshRenderer mr2 = child2.GetComponent<MeshRenderer>();
                            if (mr2 != null)
                            {
                                segmentDict.TryGetValue("Box", out Color32 outColor);
                                mpb.SetColor("_SegmentColor", outColor);
                                mr2.SetPropertyBlock(mpb);
                            }
                        }
                    }
                }

                // Bed
                if (name[0] == "Bed")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            name[0] = "Bed";
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }

                        foreach (Transform child2 in child.transform)
                        {
                            // MR
                            MeshRenderer mr2 = child2.GetComponent<MeshRenderer>();
                            if (mr2 != null)
                            {
                                segmentDict.TryGetValue("Bed", out Color32 outColor);
                                mpb.SetColor("_SegmentColor", outColor);
                                mr2.SetPropertyBlock(mpb);
                            }
                        }
                    }
                }

                // Sofa
                if (name[0] == "Sofa")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            name[0] = "Sofa";
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }

                        foreach (Transform child2 in child.transform)
                        {
                            // MR
                            MeshRenderer mr2 = child2.GetComponent<MeshRenderer>();
                            if (mr2 != null)
                            {
                                segmentDict.TryGetValue("Sofa", out Color32 outColor);
                                mpb.SetColor("_SegmentColor", outColor);
                                mr2.SetPropertyBlock(mpb);
                            }
                        }
                    }
                }
            }

            if (name.Length >= 2)
            {

                // Floor_Lamp
                if (name[0] == "Floor" && name[1] == "Lamp")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue(name[0], out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // AlarmClock
                if (name[0] == "Alarm" && name[1] == "Clock")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue("AlarmClock", out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }

                        foreach (Transform child2 in child.transform)
                        {
                            // MR
                            MeshRenderer mr2 = child2.GetComponent<MeshRenderer>();
                            if (mr2 != null)
                            {
                                segmentDict.TryGetValue("AlarmClock", out Color32 outColor);
                                mpb.SetColor("_SegmentColor", outColor);
                                mr2.SetPropertyBlock(mpb);
                            }
                        }
                    }
                }

                // ShelvingUnit
                if (name[0] == "Shelving" && name[1] == "Unit")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue("ShelvingUnit", out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                        else
                        {
                            string[] childName = child.name.Split('_');
                            if (childName.Length >= 1)
                            {
                                foreach (Transform child2 in child.transform)
                                {
                                    string[] child2Name = child2.name.Split('_');
                                    MeshRenderer child2MR = child2.GetComponent<MeshRenderer>();
                                    if (child2MR != null && childName[0] == "Shelf")
                                    {
                                        segmentDict.TryGetValue(childName[0], out Color32 outColorChild);
                                        mpb.SetColor("_SegmentColor", outColorChild);
                                        child2MR.SetPropertyBlock(mpb);
                                    }
                                }
                            }
                        }
                    }
                }

                // DeskLamp
                if (name[0] == "Desk" && name[1] == "Lamp")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue("DeskLamp", out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // WallDecor
                if (name[0] == "Wall" && name[1] == "Decor")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue("RoomDecor", out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // TennisRacket
                if (name[0] == "Tennis" && name[1] == "Racket")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue("TennisRacket", out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // SprayBottle
                if (name[0] == "Spray" && name[1] == "Bottle")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue("SprayBottle", out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // VaseFlat
                if (name[0] == "Vase" && name[1] == "Flat")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue("Vase", out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }

                // CoffeeTable
                if (name[0] == "thorkea" && name[1] == "coffee")
                {
                    foreach (Transform child in go.transform)
                    {
                        // MR
                        MeshRenderer mr = child.GetComponent<MeshRenderer>();
                        if (mr != null)
                        {
                            segmentDict.TryGetValue("ShelvingUnit", out Color32 outColor);
                            mpb.SetColor("_SegmentColor", outColor);
                            mr.SetPropertyBlock(mpb);
                        }
                    }
                }
            }
        }

        /*string name = go.name.Split('_')[0];
        GameObject mesh;
        if (segmentDict.TryGetValue(name, out Color32 outColor))
        {
            if (name == "wall")
            {
                foreach (Transform child in go.transform)
                {
                    if (child.name == "CabinetDoor")
                    {
                        GameObject CabinetDoor = child.gameObject;
                        foreach (Transform child2 in CabinetDoor.transform)
                        {
                            if (child2.name == "mesh" || child2.name == "Mesh")
                            {
                                mesh = child2.gameObject;
                                var renderer = mesh.GetComponent<MeshRenderer>();
                                mpb.SetColor("_SegmentColor", outColor);
                                renderer.SetPropertyBlock(mpb);
                            }
                        }
                    }
                }

            }
            else
            {
                foreach (Transform child in go.transform)
                {
                    if (child.name == "mesh" || child.name == "Mesh")
                    {
                        mesh = child.gameObject;
                        var renderer = mesh.GetComponent<MeshRenderer>();
                        mpb.SetColor("_SegmentColor", outColor);
                        renderer.SetPropertyBlock(mpb);
                    }
                }
            }
        }
    }*/

        foreach (GameObject go in structure)
        {
            string[] name = go.name.Split('_');
            if (name.Length >= 2)
            {
                if (name[0] == "wall" && name[1] == "panel")
                {
                    segmentDictStructure.TryGetValue(name[0] + name[1], out Color32 outColor);
                    var renderer = go.GetComponent<MeshRenderer>();
                    mpb.SetColor("_SegmentColor", outColor);
                    renderer.SetPropertyBlock(mpb);
                }
                else
                {
                    string thename = "";
                    if (name.Length >= 3)
                    {
                        if (name[2] == "floor")
                        {
                            thename = "Floor";
                        }
                        else if (name[2][0] == 'v')
                        {
                            thename = "Vent";
                        }
                    }
                    else if (name[1] == "ceiling")
                    {
                        thename = "Ceiling";
                    }
                    else if (name[0] == "Wall")
                    {
                        thename = "Wall";
                    }
                    MeshRenderer mr = go.GetComponent<MeshRenderer>();
                    if (mr != null)
                    {
                        segmentDictStructure.TryGetValue(thename, out Color32 outColor);
                        mpb.SetColor("_SegmentColor", outColor);
                        mr.SetPropertyBlock(mpb);
                    }
                }
            }


            /*foreach (Transform child in go.transform)
            {
                if (child.name == "mesh" || child.name == "Mesh")
                {
                    mesh = child.gameObject;
                    var renderer = mesh.GetComponent<MeshRenderer>();
                    mpb.SetColor("_SegmentColor", outColor);
                    renderer.SetPropertyBlock(mpb);
                }
            }*/
        }

        // Finally set the Segment shader as replacement shader
        segmentCamera.SetReplacementShader(segmentShader, "RenderType");
    }
}