export default class HeirsModel {
   constructor (
      /**
       * Id
       */
      public Id: number,

      /**
       * Имя
       */
      public Name: string,
      /**
       * Фамилия
       */
      public Surname: string,

      /**
       * Отчество
       */
      public Patronymic: string,

      /**
       * Дата рождения
       */
      public DateOfBirth: string,
      
      /**
       * Степень родства
       */
      public RelationDegree: string,

      /**
       * Адрес
       */
      public Address: string,

      /**
       * % Выплаты
       */
      public PayoutPercentAge: number,

      /**
       * Поля с ошибками
       */
      public ErrorName?: string,
      public ErrorSurname?: string,
      public ErrorPatronymic?: string,
      public ErrorDateOfBirth?: string,
      public ErrorRelationDegree?: string, 
      public ErrorAddress?: string,
      public ErrorPayoutPercentAge?: string
   ) {}
}