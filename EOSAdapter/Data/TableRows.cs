using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRows
{
    public List<Dictionary<string, Object>> rows;
    public bool more;
    public  override string ToString()
    {
        return "TableRows{" +
                "rows=" + rows +
                ", more=" + more +
                '}';
    }
}