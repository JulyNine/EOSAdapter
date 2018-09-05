using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountInfo
{
    public string account_name;
    public bool privileged;
    public string last_code_update;
    public string created;
    public long ram_quota;
    public long net_weight;
    public long cpu_weight;
    public Dictionary<string, long> net_limit;
    public Dictionary<string, long> cpu_limit;
    public long ram_usage;
    public AccountPermission[] permissions;

    public string total_resources;
    public string self_delegated_bandwidth;
    public string voter_info;

    public override string ToString()
    {
        return "AccountInfo{" +
                "account_name='" + account_name + '\'' +
                ", privileged=" + privileged +
                ", last_code_update='" + last_code_update + '\'' +
                ", created='" + created + '\'' +
                ", ram_quota=" + ram_quota +
                ", net_weight=" + net_weight +
                ", cpu_weight=" + cpu_weight +
                ", net_limit=" + net_limit +
                ", cpu_limit=" + cpu_limit +
                ", ram_usage=" + ram_usage +
                ", permissions=" + permissions.ToString()+
                ", total_resources='" + total_resources + '\'' +
                ", self_delegated_bandwidth='" + self_delegated_bandwidth + '\'' +
                ", voter_info='" + voter_info + '\'' +
                '}';
    }
}



public class AccountPermission
{
    public string perm_name;
    public string parent;
    public RequiredAuth required_auth;

    public override string ToString()
    {
        return "AccountPermission{" +
                "perm_name='" + perm_name + '\'' +
                ", parent='" + parent + '\'' +
                ", required_auth=" + required_auth +
                '}';
    }
}

public class RequiredAuth
{
    public int threshold;
    public KeyWeights[] keys;
    public string[] accounts;
    public string[] waits;

    public override string ToString()
    {
        return "RequiredAuth{" +
                "threshold=" + threshold +
                ", keys=" + keys.ToString() +
                ", accounts=" + accounts.ToString() +
                ", waits=" + waits.ToString() +
                '}';
    }
}

public class KeyWeights
{
    public string key;
    public int weight;
    public override string ToString()
    {
        return "KeyWeights{" +
                "key='" + key + '\'' +
                ", weight=" + weight +
                '}';
    }
}