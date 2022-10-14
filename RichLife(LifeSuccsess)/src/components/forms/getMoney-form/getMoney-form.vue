<template>
   <div class="getMoney-form-wrap">

      <div class="getMoney-form">
         <div class="grid-item">
            <i-new-input 
               ref="name"
               v-model="name"
               :name="'name'"
               :placeholder="'Ivan'"
               :required="true"
               :regex="nameRegexLat"
               :label="'Имя'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Введите Имя латинскими буквами, как в загран паспорте.</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="surname"
               v-model="surname"
               :name="'surname'"
               :placeholder="'Ivanov'"
               :required="true"
               :regex="nameRegexLat"
               :label="'Фамилия'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Введите Фамилию латинскими буквами, как в загран паспорте.</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="email"
               v-model="email"
               :name="'email'"
               :placeholder="'example@gmail.com'"
               :required="true"
               :regex="emailRegex"
               :label="'Email'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Указывайте ТОЛЬКО gmail (Google-почта)</template>
            </i-new-input>
         </div>

         <div class="grid-item flex-item phone-item">
            <i-new-input 
               class="phone"
               ref="phone"
               v-model="phone"
               :name="'phone'"
               :placeholder="'565 556 56 65'"
               :required="true"
               :regex="phoneRegex"
               :label="'Телефон'"
               hasLabel
               hasTooltip
               light
               showError
               isPhone>
               <langs-dropdown class="hasLabel" :isPhone="true" :absolute="true"></langs-dropdown>
               <template slot="tooltip">Укажите номер телефона без кода страны. Если номер ПМР, то введите его в формате: 779 123 45</template>
            </i-new-input>
         </div>

         <div class="grid-item column100">
            <i-dropdown 
               :items="paymentTypes" 
               :label="'Выберите способ вывода'"
               @selected="onSelect"
               light
               hasLabel></i-dropdown>
         </div>
      </div>

      <transition name="fadeLeft" mode="out-in">
         <!-- Платежная карта -->
         <div class="additional-block" v-if="activePayment == 1" :key="activePayment">
            <h3 class="additional-title" v-if="selectedPaymentType">{{ selectedPaymentType.Name }}</h3>

            <div class="grid-content">
               <div class="grid-item">
                  <i-new-input 
                     ref="card"
                     v-model="card"
                     :name="'card'"
                     :placeholder="'5555 5555 5555 5555'"
                     :required="true"
                     :regex="cardRegex"
                     :label="'Номер карты'"
                     hasLabel
                     light
                     showError
                     isCard
                  />
               </div>

               <div class="grid-item">
                  <i-new-input 
                     ref="cvv"
                     v-model="cvv"
                     :name="'cvv'"
                     :placeholder="'356'"
                     :maxlength="3"
                     :minlength="3"
                     :required="true"
                     :regex="numberRegex"
                     :label="'CVV2 / CVC2'"
                     hasLabel
                     light
                     showError
                     isStandart
                  />
               </div>

               <div class="grid-item">
                  <i-new-input 
                     ref="month"
                     v-model="month"
                     :name="'month'"
                     :placeholder="'02'"
                     :maxlength="2"
                     :minlength="2"
                     :required="true"
                     :regex="numberRegex"
                     :label="'Месяц (срок действия)'"
                     hasLabel
                     hasTooltip
                     light
                     showError
                     isStandart
                  >
                     <template slot="tooltip">Укажите номер месяца в двузначном формате</template>
                  </i-new-input>
               </div>

               <div class="grid-item">
                  <i-new-input 
                     ref="year"
                     v-model="year"
                     :name="'year'"
                     :placeholder="'21'"
                     :maxlength="2"
                     :minlength="2"
                     :required="true"
                     :regex="numberRegex"
                     :label="'Год (срок действия)'"
                     hasLabel
                     hasTooltip
                     light
                     showError
                     isStandart
                  >
                     <template slot="tooltip">Укажите год в двузначном формате</template>
                  </i-new-input>
               </div>
            </div>
         </div>

         <!-- QIWI -->
         <div class="additional-block" v-if="activePayment == 2" :key="activePayment">
            <h3 class="additional-title" v-if="selectedPaymentType">{{ selectedPaymentType.Name }}</h3>

            <div class="grid-content column1">
               <div class="grid-item flex-item phone-item">
                  <p class="additional-text" @click="assignNumberPhone">Использовать для QIWI кошелька номер, указанный выше</p>
                  <i-new-input 
                     class="phone"
                     ref="phoneQIWI"
                     v-model="phoneQIWI"
                     :name="'phoneQIWI'"
                     :placeholder="'565 556 56 65'"
                     :required="true"
                     :regex="phoneRegex"
                     :label="'QIWI кошелек'"
                     hasLabel
                     light
                     showError
                     isPhone>
                     <langs-dropdown class="hasLabel" :isPhone="true" :absolute="true"></langs-dropdown>
                  </i-new-input>
               </div>
            </div>
         </div>
      </transition>
      <i-button @onClick="isValidationClick" :height="'45px'" :fontSize="'16px'" :margin="'30px 0 0 0'" :padding="'13px 25px'" :maxWidth="'170px'">Отправить</i-button>
   </div>
</template>

<script lang="ts">
import IDropdownModel from "@components/i-dropdown/models/IDropdownModel";
import Vue from "vue";
import { Component, Watch } from "vue-property-decorator";

@Component
export default class GetMoneyFormComponent extends Vue {

   /**
    * Переменные - v-model инпутов
    */
   name: string = ''  // value имя
   surname: string = ''  // value фамилия
   email: string = ''  // value email
   phone: string = ''  // value phone
   card: string = ''  // номер платежной карты
   cvv: number = null  // CVV2/CVC2
   month: number = null  // номер месяца (срок действия карты)
   year: number = null  // год (срок действия карты)
   phoneQIWI: string = ''  // кошелек QIWI

   pos: number = null

   /**
    * переменные - текст ошибки при валидации
    */
   errorName: string = ''
   errorSurname: string = ''
   errorEmail: string = ''
   errorPhone: string = ''
   errorCard: string = ''
   errorCvv: string = ''
   errorMonth: string = ''
   errorYear: string = ''
   errorPhoneQIWI: string = ''


    /**
    * Модель для способов оплаты
    */
   paymentTypes: IDropdownModel[] = []  // список способов оплаты
   activePayment: number = 1 // флаг для отображения активного блока оплаты с дополнительной инфой

   /**
    * Инициализация выбранного способа оплаты при отрисовки компонента
    */
   selectedPaymentType: IDropdownModel = {
      Id: 1,
      Name: 'Платежная карта',
      Selected: true,
      Disabled: false
   }
 
   /**
    * Валидация формы
    */
   valid: boolean = false  // флаг на валидацию формы

   /**
    * Регулярки
    */
   nameRegex: RegExp = /^[A-zА-я\s^_][^0-9\s_]+$/; //'[\\w\s]+'; // имя
   nameRegexLat: RegExp = /^\w+([- _]\w+)*$/ // имя на литинском
   phoneRegex: RegExp = /^(\s*)?(\+)?([- _():+]?\d[- _():+]?){8,14}(\s*)?$/; // телефон
   numberRegex: RegExp = /^[0-9]+$/ // только числа
   cardRegex: RegExp = /(?<!\d)\d{16}(?!\d)|(?<!\d[ _-])(?<!\d)\d{4}(?=([_ -]))(?:\1\d{4}){3}(?![_ -]?\d)/ // платежная карта
   emailRegex: RegExp = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/ // email 


   created() {
      this.paymentTypes = [
         new IDropdownModel(1, 'Платежная карта', true, false),
         new IDropdownModel(2, 'QIWI', false, false)
      ] 
   }



   /**
    * Получение выбранного способа платежа из i-dropdown
    */
   onSelect(selected: IDropdownModel) {
      this.selectedPaymentType = selected
      this.selectPaymenyBlock()
   }


   /**
    * Присваивание значения phone инпуту phoneQIWI
    * Если номер кшелька и телефона одинаковые
    */
   assignNumberPhone() {
      this.phoneQIWI = this.phone
   }



   /**
    * Появление блоков с дополнительными данными
    */
   selectPaymenyBlock() {
      switch (this.selectedPaymentType.Id) {
         case 1:
            return this.activePayment = 1;
         case 2: 
            return this.activePayment = 2;
         case 3: 
            return this.activePayment = 3;
         default:
            return this.activePayment = 1;
      }
   }

   isValidationClick() {
      if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) &&
         (this.GetRef('surname') && !this.GetRef('surname').checkValidation()) && 
         (this.GetRef('phone') && !this.GetRef('phone').checkValidation()) &&
         (this.GetRef('email') && !this.GetRef('email').checkValidation()) 
      ) {
         
         console.log('форма не отправилась условие 1');
      } else if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) ||
         (this.GetRef('surname') && !this.GetRef('surname').checkValidation()) || 
         (this.GetRef('phone') && !this.GetRef('phone').checkValidation()) ||
         (this.GetRef('email') && !this.GetRef('email').checkValidation()) 
      ) {
         
         console.log('форма не отправилась условие 2');
      } else { 
         console.log('форма отправилась');
         
      }
   }




   /**
    * Валидация формы
    */
   isValid() {
      /* name */
      if (this.name == '' || this.name == undefined) {
         this.errorName = 'Это обязательное поле'
         this.valid = false
      } else if (!this.nameRegex.test(this.name)) {
         this.errorName = 'Введите корректное имя'
         this.valid = false
      } else {
         this.errorName = '';
         this.valid = true
      }
            

      /* surname */
      if (this.surname == '' || this.surname == undefined) {
         this.errorSurname = 'Это обязательное поле'
         this.valid = false
      } else if (!this.nameRegex.test(this.surname)) {
         this.errorSurname = 'Введите корректую фамилию'
         this.valid = false
      } else {
         this.errorSurname = '';
         this.valid = true
      }


      /* email */
      if (this.email == '' || this.email == undefined) {
         this.errorEmail = 'Это обязательное поле'
         this.valid = false
      } else if (!this.validEmail(this.email)) {
         this.errorEmail = 'Введите корректный email'
         this.valid = false
      } else {
         this.errorEmail = ''
         this.valid = true
      }

            
      /* phone */
      if (this.phone == '' || this.phone == undefined) {
         this.errorPhone = 'Это обязательное поле'
         this.valid = false
      } else if (!this.phoneRegex.test(this.phone)) {
         this.errorPhone = 'Введите корректный номер телефона'
         this.valid = false
      } else {
         this.errorPhone = ''
         this.valid = true
      }


      /* Номер платежной карты */
      if (this.card == null || this.card == '' || this.card == undefined) {
         this.errorCard = 'Это обязательное поле'
         this.valid = false
      } else if (!this.cardRegex.test(this.card)) {
         this.errorCard = 'Проверьте еще раз'
         this.valid = false
      } else {
         this.errorCard = '';
         this.valid = true
      }

      /* Номер платежной карты */
      if (this.cvv == null || this.cvv == 0 || this.cvv == undefined) {
         this.errorCvv = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.cvv)) {
         this.errorCvv = 'Проверьте еще раз'
         this.valid = false
      } else {
         this.errorCvv = '';
         this.valid = true
      }

      /* Месяц (срок действия карты) */
      if (this.month == null || this.month == 0 || this.month == undefined) {
         this.errorMonth = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.month)) {
         this.errorMonth = 'Введите двузначное число'
         this.valid = false
      } else if (this.month > 12) {
         this.errorMonth = 'Повнимательнее'
      } else {
         this.errorMonth = '';
         this.valid = true
      }

      /* Год (срок действия карты) */
      if (this.year == null || this.year == 0 || this.year == undefined) {
         // this.errorYear = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.year)) {
         // this.errorYear = 'Введите двузначное число'
         this.valid = false
      } else {
         // this.errorYear = '';
         this.valid = true
      }

      /* QIWI кошелек */
      if (this.phoneQIWI == '' || this.phoneQIWI == undefined) {
         this.errorPhoneQIWI = 'Это обязательное поле'
         this.valid = false
      } else if (!this.phoneRegex.test(this.phoneQIWI)) {
         this.errorPhoneQIWI = 'Введите корректный номер телефона'
         this.valid = false
      } else {
         this.errorPhoneQIWI = ''
         this.valid = true
      }

      if (this.pos == null || this.pos === undefined) {
         this.valid = false
      } else {
         this.valid = true
      }


      if (this.valid) {
         console.log('форма отправилась');
      } else {
         console.log('форма не отправилась');
      }
            
   }

   /**
    * Валидация Email
    */
   validEmail(value: string): boolean {
      let reg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return reg.test(value);
   }

}
</script>

<style scoped>

.getMoney-form-wrap {
   margin: 0 auto;
   max-width: 900px;
   width: 100%;
}

.getMoney-form {
   display: grid;
   grid-template-columns: 1fr 1fr;
   grid-template-rows: auto;
   column-gap: 15px;
   row-gap: 21px;
}

.grid-item.column100 {
   grid-column: 1/3;
}



/* блоки с дополнительной инфой */
.additional-block {
   margin-top: 40px;
   opacity: 1;
   visibility: visible;
   transform: translateX(0);
}

.additional-title {
   margin-bottom: 20px;
   font-size: 19px;
   font-weight: 700;
   line-height: 120%;
   color: #121B23;
}

.additional-text {
   margin-bottom: 20px;
   display: inline-block;
   font-size: 13px;
   font-weight: 600;
   line-height: 140%;
   color: #121B23;
   cursor: pointer;
   max-width: 100%;
   transition: all 0.2s ease-out;
}

.additional-text:hover {
   color: #12be83;
}

.grid-content {
   display: grid;
   grid-template-columns: 1fr 1fr;
   grid-template-rows: auto;
   column-gap: 15px;
   row-gap: 21px;
}

.grid-content.column1 {
   grid-template-columns: 1fr;
}






.fadeLeft-enter-active, .fadeLeft-leave-active {
   transition: all 0.3s ease-out;
}

.fadeLeft-enter, .fadeLeft-leave-to {
   opacity: 0;
   visibility: hidden;
   transform: translateX(-5%);
}


@media all and (max-width: 580px) {
   .getMoney-form, .grid-content { grid-template-columns: 1fr; }
   .grid-item.column100 { grid-column: 1/2; }
}
</style>