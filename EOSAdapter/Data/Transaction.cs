using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Globalization;
public class Transaction
{
    public string expiration;
    public long ref_block_num;
    public long ref_block_prefix;
    public int max_net_usage_words;
    public int max_cpu_usage_ms;
    public int delay_sec;
    public List<string> context_free_actions = new List<string>();
    public List<EOSAction> actions = new List<EOSAction>();
    public List<string> transaction_extensions = new List<string>();
    public List<string> signatures = new List<string>();
    public List<string> context_free_data = new List<string>();

    protected Transaction()
    {
    }

    public Transaction(string expiration,
                       long ref_block_num,
                       long ref_block_prefix,
                       int max_net_usage_words,
                       int max_cpu_usage_ms,
                       int delay_sec,
                       List<string> context_free_actions,
                       List<EOSAction> actions,
                       List<string> transaction_extensions,
                       List<string> signatures,
                       List<string> context_free_data)
    {
        this.expiration = expiration;
        this.ref_block_num = ref_block_num;
        this.ref_block_prefix = ref_block_prefix;
        this.max_net_usage_words = max_net_usage_words;
        this.max_cpu_usage_ms = max_cpu_usage_ms;
        this.delay_sec = delay_sec;
        this.context_free_actions = (context_free_actions != null ? context_free_actions : new List<string>());
        this.actions = (actions != null ? actions : actions);
        this.transaction_extensions = (transaction_extensions != null ? transaction_extensions : new List<string>());
        this.signatures = (signatures != null ? signatures : new List<string>());
        this.context_free_data = (context_free_data != null ? context_free_data : new List<string>());
    }


    public  void Pack(ByteBuffer writer)
    {
        //string expiration = "2018-08-06T06:21:03.000";
        DateTime date;
      //  DateTime.TryParse(expiration,System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out date);
        //Debug.Log("data" + date.ToLongTimeString());

        DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
        dtFormat.ShortDatePattern = "yyyy-MM-dd'T'HH:mm:ss";
        date = Convert.ToDateTime(expiration, dtFormat);
        Debug.Log("date" + date.ToLongTimeString());


        DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        TimeSpan ts = date.Subtract(dt1970);
          Debug.Log( ts.TotalSeconds);
        Debug.Log((date.Ticks - dt1970.Ticks) / 1000000000);
        writer.WriteInt((int)((uint)ts.TotalSeconds & 0xFFFFFFFF));
       // writer.WriteInt((int)(1535711728 & 0xFFFFFFFF));
        //return;
        writer.WriteShort((short)(ref_block_num & 0xFFFF));
        writer.WriteInt((int)(ref_block_prefix & 0xFFFFFFFF));
        writer.WriteVariableUInt(max_net_usage_words);
        writer.WriteVariableUInt(max_cpu_usage_ms);
        writer.WriteVariableUInt(delay_sec);
        writer.WriteVariableUInt(0);
        writer.WriteVariableUInt(actions.Count);
        for(int i = 0; i < actions.Count; i++)
        {
            actions[i].Pack(writer);
        }
        writer.WriteVariableUInt(0);
        /*

        // Pack the Transaction Header
        TimeZone tz = TimeZone.getTimeZone("UTC");
        DateFormat sdf = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");
    sdf.setTimeZone(tz);
        Date expirationDate = sdf.parse(expiration);
    int expSecs = (int)(expirationDate.getTime() / 1000);
    writer.putInt(expSecs);
        writer.putShort((short) (ref_block_num & 0xFFFF));
        writer.putInt((int) (ref_block_prefix & 0xFFFFFFFF));
        writer.putVariableUInt(max_net_usage_words);
        writer.putVariableUInt(max_cpu_usage_ms);
        writer.putVariableUInt(delay_sec);

        // Pack the Context Free Actions
        writer.putVariableUInt(0);

        // Pack the Actions
        writer.putVariableUInt(actions.size());
        for (Transaction.Action action : actions) {
            action.pack(writer);
        }

// Pack the Transaction Extensions
writer.putVariableUInt(0);
*/
    }

    
    public override string ToString()
    {
        return "Transaction{" +
                "expiration='" + expiration + '\'' +
                ", ref_block_num='" + ref_block_num + '\'' +
                ", ref_block_prefix='" + ref_block_prefix + '\'' +
                ", max_net_usage_words=" + max_net_usage_words +
                ", max_cpu_usage_ms=" + max_cpu_usage_ms +
                ", delay_sec=" + delay_sec +
                ", context_free_actions=" + context_free_actions +
                ", actions=" + actions +
                ", transaction_extensions=" + transaction_extensions +
                ", signatures=" + signatures +
                ", context_free_data=" + context_free_data +
                '}';
    }

    public class Response
    {
        public string transaction_id;
        public Dictionary<string, object> processed;

        public override string ToString()
        {
            return "Response{" +
                    "transaction_id='" + transaction_id + '\'' +
                    ", processed=" + processed +
                    '}';
        }
    }

    public class EOSAction
    {
        public string account;
        public string name;
        public List<Authorization> authorization;
        public string data;

        public EOSAction()
        {
        }

        public EOSAction(string account, string name, List<Authorization> authorization, string data)
        {
            this.account = account;
            this.name = name;
            this.authorization = authorization;
            this.data = data;
        }

        public override string ToString()
        {
            return "Action{" +
                    "account='" + account + '\'' +
                    ", name='" + name + '\'' +
                    ", authorization=" + authorization +
                    ", data='" + data + '\'' +
                    '}';
        }

       
        public void Pack(ByteBuffer writer)
        {

            //Base32Encoder base32 = new Base32Encoder();
            writer.WriteLong(Base32.Decode(account));
            writer.WriteLong(Base32.Decode(name));
            //writer.WriteBytes(base32.Decode(name));
            writer.WriteVariableUInt(authorization.Count);
            for (int i = 0; i < authorization.Count; i++)
            {
                authorization[i].Pack(writer);
            }
            byte[] decodedData = ByteBuffer.HexStringToBytes(data);
            writer.WriteVariableUInt(decodedData.Length);
            writer.WriteBytes(decodedData);
        }
    }
    public class Authorization
    {
        public string actor;
        public string permission;

        public Authorization()
        {
        }

        public Authorization(string actor, string permission)
        {
            this.actor = actor;
            this.permission = permission;
        }

        public void Pack(ByteBuffer writer)
        {
           // Base32Encoder base32 = new Base32Encoder();
           // writer.WriteBytes(base32.Decode(actor));
           // writer.WriteBytes(base32.Decode(permission));
            writer.WriteLong(Base32.Decode(actor));
            writer.WriteLong(Base32.Decode(permission));
        }
        
        public override string ToString()
        {
            return "Authorization{" +
                    "actor='" + actor + '\'' +
                    ", permission='" + permission + '\'' +
                    '}';
        }
    }


}





