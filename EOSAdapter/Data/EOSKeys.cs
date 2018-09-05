using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EOSKeys
{

    public List<KeyPair> keyPairList;

    public class KeyPair
    {
        public string publicKey;
        public string privateKey;

        public KeyPair(string publicKey, string privateKey)
        {
            this.publicKey = publicKey;
            this.privateKey = privateKey;
        }
    }
}
