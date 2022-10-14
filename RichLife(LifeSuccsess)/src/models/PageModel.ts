export default class PageModel {
   /**
    * Общее кол-во элементов 
    */
   Count: number;

   /**
    * Кол-во элементов, отображаемых на одной странице
    */
   Size: number;

   /**
    * Номер текущей страницы
    */
   Current: number

   constructor(Count: number, Size: number, Current: number) {
      this.Count = Count,
      this.Size =  Size,
      this.Current = Current
   }
}