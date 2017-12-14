using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DateSaveManager : DonDeleteSingleton<DateSaveManager> {
    public DateRoot ClassRoad(string classname, EnumDate.E_PrefabsDate datetype) {
        DateRoot dr = null;
        string str = PlayerPrefs.GetString(classname);

        if (string.IsNullOrEmpty(str))
            return null;

        BinaryFormatter bt = new BinaryFormatter();
        MemoryStream ms = new MemoryStream(Convert.FromBase64String(str));

        switch (datetype) {
            case EnumDate.E_PrefabsDate.UPGRADE:

                dr = (UpgradeDate)bt.Deserialize(ms);
                break;
        }

        return dr;
    }

    public void ClassSave(string className, DateRoot sd) {
        BinaryFormatter bt = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bt.Serialize(ms, sd);
        PlayerPrefs.SetString(className, Convert.ToBase64String(ms.GetBuffer()));
    }
}
