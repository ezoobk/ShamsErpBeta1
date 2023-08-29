
using System.Data;
using System.Drawing;


namespace ShamsErpBeta.Classes
{
    class VariablesClass
    {
        public static int userId, receiptType;
        public static int TreasuryId = 1, receiveReceiptId, payReceiptId;
        public static string userName, userPassword, userJob, phoneNum;
        public static Point pos;
        public static bool backupProcess;
        public static bool sw;
        //public static bool mainActive;
        public static int Save = -1;
        public static DataTable dtShering { get; set; }
    }
}
