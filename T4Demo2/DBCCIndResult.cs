#region Code

namespace T4Demo2 {
    /// <summary>
    ///     实体-DBCCIndResult
    /// </summary>
    public class DBCCIndResult {
        /// <summary>
        ///     PageFID
        ///     <summary>
        public byte PageFID { get; set; }

        /// <summary>
        ///     PagePID
        ///     <summary>
        public int PagePID { get; set; }

        /// <summary>
        ///     IAMFID
        ///     <summary>
        public byte? IAMFID { get; set; }

        /// <summary>
        ///     IAMPID
        ///     <summary>
        public int? IAMPID { get; set; }

        /// <summary>
        ///     ObjectID
        ///     <summary>
        public int? ObjectID { get; set; }

        /// <summary>
        ///     IndexID
        ///     <summary>
        public byte? IndexID { get; set; }

        /// <summary>
        ///     PartitionNumber
        ///     <summary>
        public byte? PartitionNumber { get; set; }

        /// <summary>
        ///     PartitionID
        ///     <summary>
        public long? PartitionID { get; set; }

        /// <summary>
        ///     iam_chain_type
        ///     <summary>
        public string iam_chain_type { get; set; }

        /// <summary>
        ///     PageType
        ///     <summary>
        public byte? PageType { get; set; }

        /// <summary>
        ///     IndexLevel
        ///     <summary>
        public byte? IndexLevel { get; set; }

        /// <summary>
        ///     NextPageFID
        ///     <summary>
        public byte? NextPageFID { get; set; }

        /// <summary>
        ///     NextPagePID
        ///     <summary>
        public int? NextPagePID { get; set; }

        /// <summary>
        ///     PrevPageFID
        ///     <summary>
        public int? PrevPageFID { get; set; }

        /// <summary>
        ///     PrevPagePID
        ///     <summary>
        public int? PrevPagePID { get; set; }
    }
}

#endregion