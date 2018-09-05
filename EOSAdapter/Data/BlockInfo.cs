using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInfo
{
    public string timestamp;
    public string producer;
    public long confirmed;
    public string previous;
    public string transaction_mroot;
    public string action_mroot;
    public long schedule_version;
    public List<string> new_producers;
    public List<string> header_extensions;
    public string producer_signature;
    public List<BlockTransaction> transactions;
    public List<string> block_extensions;


    public string regions;
    public string input_transactions;
    public string id;
    public long block_num;
    public long ref_block_prefix;
    public override string ToString()
    {
        return "BlockInfo{" +
                "timestamp='" + timestamp + '\'' +
                ", producer='" + producer + '\'' +
                ", confirmed=" + confirmed +
                ", previous='" + previous + '\'' +
                ", transaction_mroot='" + transaction_mroot + '\'' +
                ", action_mroot='" + action_mroot + '\'' +
                ", schedule_version=" + schedule_version +
                ", new_producers=" + new_producers +
                ", header_extensions=" + header_extensions +
                ", producer_signature='" + producer_signature + '\'' +
                ", transactions=" + transactions +
                ", block_extensions=" + block_extensions +
                ", regions='" + regions + '\'' +
                ", input_transactions='" + input_transactions + '\'' +
                ", id='" + id + '\'' +
                ", block_num=" + block_num +
                ", ref_block_prefix=" + ref_block_prefix +
                '}';
    }
}

public class BlockTransaction :Transaction
{
        public string status;
        public long cpu_usage_us;
        public long net_usage_words;
        public TransactionInfo trx;
}
public class TransactionInfo
{
        public string id;
        public List<string> signatures;
        public string compression;
        public string packed_context_free_data;
        public List<string> context_free_data;
        public string packed_trx;
        public Transaction transaction;
}