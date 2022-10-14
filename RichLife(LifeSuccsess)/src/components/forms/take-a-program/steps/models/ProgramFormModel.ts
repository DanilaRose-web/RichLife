import HearsModel from "../../heirs/HearsModel";

export default class ProgramFormModel {
   constructor (
      public Name?: string,
      public Surname?: string,
      public Patronymic?: string,
      public DateOfBirth?: string,
      public Age?: number,
      public MaidenName?: string,
      public PasportNumber?: string,
      public PasportSeries?: string,
      public Inn?: number,
      public Phone?: string,
      public Email?: string,
      public MaritalStatus?: string,
      public Attitude?: string,
      public PlaceOfWork?: string,
      public Position?: string,
      public Responsibilities?: string,
      public ManOrWoman?: string,
      public AddictedPeople?: number,
      public PlaceOfResidence?: string,
      public AddressMail?: string,
      public IndexEmail?: number,
      public LeftOrRight?: string,
      public Motorcyclist?: boolean,
      public Height?: number,
      public Weight?: number,
      public CountOfCigarettes?: number,
      public CountOfAlcohol?: number,
      public KindOfAlcohol?: string,
      public Income?: number,
      public Profit?: number,
      public Hears?: Array<HearsModel>
   ) {}
}