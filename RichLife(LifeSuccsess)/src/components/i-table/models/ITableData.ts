export default class ITableData {
   constructor (
      public Id: number,
      public PolicyNumber: number,
      public Data: string,
      public Name: string,
      public EScores: number,
      public Cashback: number,
      public MoneyToPay: number  
   ) {}
}