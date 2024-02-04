using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EstructuresAvançades
{
    public class TaulaHash<V>
    {
        private static int DEFAULT_MIDA = 10;

        private int mida;
        private List<KeyValuePair<String, V>>[] data;

        public TaulaHash() : this(DEFAULT_MIDA) { }
        public TaulaHash(int mida)
        {
            if (mida < 2) throw new Exception("La mida de la taula hash ha de ser 2 o més.");

            this.mida = mida;

            //crear la data
            data = new List<KeyValuePair<String, V>>[mida];

            //crear les llistes a cada posició de la data
            for (int i = 0; i < mida; i++)
                data[i] = new List<KeyValuePair<String, V>>();
        }

        public void Clear()
        {
            for (int i = 0; i < data.Length; i++)
                data[i].Clear();
        }

        public V this[String key]
        {
            get
            {
                bool trobat = false;
                int pos = (int)Math.Abs(CalcularHash(key) % mida);
                int index = 0;

                if (data[pos].Count > 0)
                {
                    while (!trobat && index < data[pos].Count)
                    {
                        trobat = data[pos][index].Key.Equals(key);
                        if (!trobat) index++;
                    }
                }

                if (!trobat)
                    throw new Exception("No s'ha trobat cap element.");

                return data[pos][index].Value;
            }
            set
            {
                int pos = (int)Math.Abs(CalcularHash(key) % mida);

                if (data[pos].Count > 0)
                {
                    int index = 0;
                    bool trobat = false;
                    while (!trobat && index < data[pos].Count)
                    {
                        trobat = data[pos][index].Key.Equals(key);
                        if (!trobat) index++;
                    }

                    if (trobat)
                        data[pos].RemoveAt(index);
                }

                data[pos].Add(new KeyValuePair<String, V>(key, value));
            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    count += data[i].Count;
                }

                return count;
            }
        }

        public bool Contains(String key)
        {
            bool trobat = false;
            int pos = (int)Math.Abs(CalcularHash(key) % mida);

            if (data[pos].Count > 0)
            {
                int index = 0;
                while (!trobat && index < data[pos].Count)
                {
                    trobat = data[pos][index].Key.Equals(key);
                    if (!trobat) index++;
                }
            }

            return trobat;
        }

        public void Add(String key, V value)
        {
            int pos = (int)Math.Abs(CalcularHash(key) % mida);

            if (data[pos].Count > 0)
            {
                int index = 0;
                bool trobat = false;
                while (!trobat && index < data[pos].Count)
                {
                    trobat = data[pos][index].Key.Equals(key);
                    if (!trobat) index++;
                }

                if (trobat)
                    throw new Exception($"La clau {key} existeix a la taula hash.");
            }

            data[pos].Add(new KeyValuePair<String, V>(key, value));
        }

        public bool Remove(String key)
        {
            int pos = key.GetHashCode() % mida;
            bool trobat = false;

            if (data[pos].Count > 0)
            {
                int index = 0;
                while (!trobat && index < data[pos].Count)
                {
                    trobat = data[pos][index].Key.Equals(key);
                    if (!trobat) index++;
                }

                if (trobat)
                    data[pos].RemoveAt(index);
            }

            return trobat;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append($"[{i}]=>");
                KeyValuePair<String, V> pair;
                sb.Append("[");
                for (int j = 0; j < data[i].Count; j++)
                {
                    if (j != 0) sb.Append(",");
                    pair = data[i][j];
                    sb.Append("{")
                        .Append(pair.Key.ToString())
                        .Append(",")
                        .Append(pair.Value.ToString())
                        .Append("}");
                }
                sb.Append("]").Append("\n");
            }

            return sb.ToString();
        }

        private long CalcularHash(String clau)
        {
            return 1;
        }

    }
}