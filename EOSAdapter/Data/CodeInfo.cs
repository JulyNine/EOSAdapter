using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeInfo
{
    public class Code
    {
        public string account_name;
        public string name;
        public string code_hash;
        public string wast;
        public string wasm;
        public ContractABI abi;

        public  class ContractABI
        {
            public string version;
            public ContractType[] types;
            public ContractStruct[] structs;
            public ContractAction[] actions;
            public ContractTable[] tables;
            public string[] ricardian_clauses;
            public string[] error_messages;
            public string[] abi_extensions;
        }

        public  class ContractType
        {
            public string new_type_name;
            public string type;
        }

        public  class ContractStruct
        {
            public string name;
            public string contractBase;
            public ContractField[] fields;
        }

        public  class ContractAction
        {
            public string name;
            public string type;
            public string ricardian_contract;
        }

        public  class ContractTable
        {
            public string name;
            public string type;
            public string index_type;
            public string[] key_names;
            public string[] key_types;
        }

        public  class ContractField
        {
            public string name;
            public string type;
        }
    }


}
