using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperCollection
{
    internal class DapperData
    {
        #region generated table scheama

        #region CsDbClassGenerator2 による自動生成

        /* コード生成日2020/08/06 10:12:44 */
        private const string _C_TABLENAME = @"TABLENAME";

        /*
            declare @ID_S int 
            declare @ID_E int
            set @ID_S = 1     
            set @ID_E = 10

            SELECT
                *
            FROM
                Person.Person
            WHERE
                BusinessEntityID >= @ID_S
            AND BusinessEntityID <= @ID_E

        BusinessEntityID
        PersonType
        NameStyle
        Title
        FirstName
        MiddleName
        LastName
        Suffix
        EmailPromotion
        AdditionalContactInfo
        Demographics
        rowguid
        ModifiedDate

        */

        public Int32 BusinessEntityID { get; set; }

        public String PersonType { get; set; }

        public Boolean NameStyle { get; set; }

        public String Title { get; set; }

        public String FirstName { get; set; }

        public String MiddleName { get; set; }

        public String LastName { get; set; }

        public String Suffix { get; set; }

        public Int32 EmailPromotion { get; set; }

        public String AdditionalContactInfo { get; set; }

        public String Demographics { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public const string SQL =
            "SELECT " +
            "    * " +
            "FROM " +
            "    Person.Person " +
            "WHERE" +
            "    BusinessEntityID >= @ID_S" +
            "AND BusinessEntityID <= @ID_E";

        //CsDbClassGenerator による自動生成(ここまでのブロックは変更すべきでは無い)

        #endregion

        #endregion
    }
}