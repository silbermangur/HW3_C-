using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Store.Enums;

namespace Store
{

    public abstract class BaseEntity
    {

        #region -- Properties
        private readonly string defaultPrefix = "store_";

        public string Id { get; set; }
        public IdType IdFormat { get; }
        #endregion


        #region --Ctor--
        public BaseEntity(IdType idFormat)
        {
            IdFormat = idFormat;
            GenerateId();
        }

        public BaseEntity() : this(IdType.GuidId) { }

        public BaseEntity(string prefix) : this(IdType.PrefixAndIndex)
        {
            defaultPrefix = prefix;
        }

        #endregion
        public override string ToString()
        {
            return Id;
        }

        private void GenerateId()
        {
            switch (IdFormat)
            {
                case IdType.GuidId:
                    Id = Guid.NewGuid().ToString();
                    break;
                case IdType.IndexId:
                    // Generate sequential index ID (1, 2, 3, ...)
                    Id = IncrementIdIndex().ToString();
                    break;
                case IdType.RandomNumberAndIndex:
                    Random random = new Random();
                    int randomNumber = random.Next(1, int.MaxValue);
                    Id = $"{randomNumber}_f{IdIndex}";
                    break;
                case IdType.PrefixAndIndex:
                    Id = $"{defaultPrefix}_f{IdIndex}";
                    break;
                default:
                    throw new ArgumentException("Invalid IdType specified.");
            }
        }


        private int IdIndex = 1; // Index for IndexId or RandomNumberAndIndex

        protected int IncrementIdIndex()
        {
            IdIndex++;
            return IdIndex;
        }
    }
}