using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignedTransaction : Transaction
{
    public SignedTransaction()
    {
        context_free_actions = new List<string>();
        actions = new List<Transaction.EOSAction>();
        signatures = new List<string>();
        transaction_extensions = new List<string>();
        context_free_data = new List<string>();
    }


    public SignedTransaction(Transaction trx, List<string> signatures)
    {
        this.expiration = trx.expiration;
        this.ref_block_num = trx.ref_block_num;
        this.ref_block_prefix = trx.ref_block_prefix;
        this.max_cpu_usage_ms = trx.max_cpu_usage_ms;
        this.max_net_usage_words = trx.max_net_usage_words;
        this.context_free_actions = new List<string>(trx.context_free_actions);
        this.actions = new List<Transaction.EOSAction>(trx.actions);
        this.transaction_extensions = new List<string>(trx.transaction_extensions);
        this.context_free_data = new List<string>(trx.context_free_data);

        this.signatures = new List<string>(signatures);
    }

}
