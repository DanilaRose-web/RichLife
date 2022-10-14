<template>
   <div class="take-a-program-form">

         <i-input 
            :label="'Имя'"
            v-model="name" 
            :error="errorName"
            :placeholder="'Имя'"
            :name="'name'"
            :regex="nameRegex"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            hasTooltip
            hasLabel
            required >
            <template slot="tooltip">
               <i-tooltip>Имя</i-tooltip>
            </template>
         </i-input>

         <i-input 
            :label="'Фамилия'"
            v-model="surname" 
            :error="errorSurname"
            :placeholder="'Фамилия'"
            :name="'surname'"
            :regex="nameRegex"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            hasLabel
            required />

         <i-input 
            :label="'Отчество'"
            v-model="patronymic" 
            :error="errorPatronymic"
            :placeholder="'Отчество'"
            :name="'patronymic'"
            :regex="nameRegex"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            hasLabel
            required />

         <i-input 
            :label="'Паспорт, свидетельство (серия)'"
            v-model="pasportSeries" 
            :error="errorPasportSeries"
            :placeholder="'Серия паспорта'"
            :name="'pasportSeries'"
            :regex="nameRegex"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            hasLabel
            required />

         <i-input 
            :label="'Паспорт, свидетельство (номер)'"
            v-model="pasportNumber" 
            :error="errorPasportNumber"
            :placeholder="'Номер паспорта'"
            :name="'pasportNumber'"
            :regex="nameRegex"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            hasLabel
            required />

         <i-input 
            :label="'ИНН (украинский)'"
            v-model="inn" 
            :error="errorInn"
            :placeholder="'ИНН'"
            :name="'inn'"
            :regex="numberRegex"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            hasLabel
            required />

         <i-input 
            :label="'Дата рождения'"
            v-model="dateOfBurth" 
            :error="errorDateOfBurth"
            :placeholder="'12.04.1996'"
            :name="'dateOfBurth'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            hasLabel
            required />
         
         <i-input 
            :label="'Полных лет'"
            v-model="age" 
            :error="errorAge"
            :placeholder="'25'"
            :name="'age'"
            :regex="phoneRegex"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            hasLabel
            required />

         <i-input 
            :label="'Семейное положение'"
            v-model="maritalStatus" 
            :error="errorMaritalStatus"
            :placeholder="'холост/не замужем/женат/замужем/в разводе'"
            :name="'maritalStatus'"
            :regex="nameRegex"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            hasLabel
            required />

         <i-input 
            :label="'Девичья фамилия (если есть)'"
            v-model="maidenName" 
            :error="errorMaidenName"
            :placeholder="'Девичья фамилия'"
            :name="'maidenName'"
            :regex="nameRegex"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            hasLabel />

         <i-input 
            :label="'Место работы'"
            v-model="placeOfWork" 
            :error="errorPlaceOfWork"
            :placeholder="'Место работы'"
            :name="'placeOfWork'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />

         <i-input 
            :label="'Должность'"
            v-model="position" 
            :error="errorPosition"
            :placeholder="'Фининансовый консультант'"
            :name="'position'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />

         <i-input 
            :label="'Служебные обязанности'"
            v-model="responsibilities" 
            :error="errorResponsibilities"
            :placeholder="'Служебные обязанности'"
            :name="'responsibilities'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />

         <i-input 
            :label="'Кол-во финансово зависимых людей'"
            v-model="addictedPeople" 
            :error="errorAddictedPeople"
            :placeholder="'Кол-во финансово зависимых людей'"
            :name="'addictedPeople'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />

         <i-input 
            :label="'Место проживания'"
            v-model="placeOfResidence" 
            :error="errorPlaceOfResidence"
            :placeholder="'Место проживания'"
            :name="'placeOfResidence'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />

         <i-input 
            :label="'Адрес для корреспонденции'"
            v-model="addressMail" 
            :error="errorAddressMail"
            :placeholder="'Адрес для корреспонденции'"
            :name="'addressMail'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />

         <i-input 
            :label="'Почтовый индекс'"
            v-model="index" 
            :error="errorIndex"
            :placeholder="'Почтовый индекс'"
            :name="'index'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />

         <i-input 
            :label="'Рост (см)'"
            v-model="height" 
            :error="errorHeight"
            :placeholder="'Рост (см)'"
            :name="'height'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />

         <i-input 
            :label="'Вес (кг)'"
            v-model="weight" 
            :error="errorWeight"
            :placeholder="'Вес (кг)'"
            :name="'weight'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />

         <i-input 
            :label="'Кол-во сигарет в день'"
            v-model="countOfCigarettes" 
            :error="errorСountOfCigarettes"
            :placeholder="'Кол-во сигарет в день'"
            :name="'countOfCigarettes'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />

         <i-input 
            :label="'Кол-во алкоголя в день (л)'"
            v-model="countOfAlcohol" 
            :error="errorCountOfAlcohol"
            :placeholder="'Кол-во сигарет в день'"
            :name="'countOfAlcohol'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />

         <i-input 
            :label="'Совокупный доход ($)'"
            v-model="income" 
            :error="errorIncome"
            :placeholder="'Совокупный доход'"
            :name="'income'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />

         <i-input 
            :label="'Чистый доход ($)'"
            v-model="profit" 
            :error="errorProfit"
            :placeholder="'Чистый доход'"
            :name="'profit'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            required
            hasLabel />
    
         <i-input 
            :label="'Email'"
            v-model="email"
            :error="errorEmail"
            :type="'email'" 
            :name="'email'"
            :placeholder="'Email'"
            :border="'1px solid rgba(18, 27, 35, 0.2)'"
            hasLabel
            required />

         <langs-dropdown :hasLabel="true" :label="'Выберите страну'" :border="'1px solid rgba(18, 27, 35, 0.2)'" :isCountry="true" :zIndex="2"></langs-dropdown>

         <div class="phone-wrap">
            <i-input 
               :label="'Телефон'"
               v-model="phone"
               :error="errorPhone"
               :type="'phone'" 
               :name="'phone'"
               :placeholder="'Телефон (без кода страны)'"
               :border="'1px solid rgba(18, 27, 35, 0.2)'"
               hasLabel
               required >
               <langs-dropdown :withInputLabel="true" :isPhone="true" ></langs-dropdown>
            </i-input>
         </div>
      

      <div class="radio-group">
         <i-input-radio :darkTheme="true" @onSelected="onSelected" :array="genderRadio" ></i-input-radio>
      </div>

      <div class="radio-group">
         <i-input-radio :darkTheme="true" @onSelected="onSelected" :array="handsRadio" ></i-input-radio>
      </div>

      <div class="checkbox-wrap">
         <input-checkbox 
            :label="'Мотоциклист'" 
            :checked="motorcyclist" 
            @click="setMotorcyclist">
         </input-checkbox>
      </div>

      <i-button :height="'max-content'" @onClick="isValid" :fontSize="'16px'" :padding="'13px 25px'" :maxWidth="'170px'">Отправить</i-button>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

import IInputRadioModel from "@components/i-input-radio/IInputRadioModel"

@Component
export default class TakeAProgramFormComponent extends Vue {

   /**
    * Переменные - v-model инпутов
    */
   name: string = ''  // имя
   surname: string = ''  // фамилия
   patronymic: string = ''  // отчество
   pasportSeries: string = ''  // серия паспорта
   pasportNumber: string = ''  // номер паспорта
   inn: number = null  // номер ИНН 
   dateOfBurth: string = ''  // дата рождения
   age: number = null  // полных лет
   maritalStatus: string = ''  // семейное положение
   maidenName: string = ''  // девичья фамилия
  
  
   
   
   
   placeOfWork: string = ''  // место работы
   position: string = ''  // Должность (работа)
   responsibilities: string = ''  // служебные обязанности
   addictedPeople: number = null  // кол-во финансово зависимых людей
   placeOfResidence: string = ''  // место проживания
   addressMail: string = ''  // почтовый адрес для корреспонденции
   index: number = null  // почтовый индекс
   height: number = null  // рост
   weight: number = null  // вес
   countOfCigarettes: number = null  // кол-во сигарет в день
   countOfAlcohol: number = null  // кол-во алкоголя в день
   income: number = null  // совокупный доход
   profit: number = null  // чистый доход
   motorcyclist: boolean = false  // мотоциклист
   email: string = ''  // email
   country: string = ''  // страна
   phone: string = ''  // phone


   

   /**
    * переменные - текст ошибки при валидации
    */
   errorName: string = ''
   errorSurname: string = ''
   errorPatronymic: string = ''
   errorEmail: string = ''
   errorPhone: string = ''
   errorPasportSeries: string = ''
   errorPasportNumber: string = '' 
   errorInn: string = '' 
   errorDateOfBurth: string = ''
   errorAge: string = '' 
   errorMaritalStatus: string = ''
   errorMaidenName: string = ''
   errorPlaceOfWork: string = ''
   errorPosition: string = ''
   errorResponsibilities: string = ''
   errorAddictedPeople: string = ''
   errorPlaceOfResidence: string = ''
   errorAddressMail: string = '' 
   errorIndex: string = ''
   errorHeight: string = ''
   errorWeight: string = ''
   errorСountOfCigarettes: string = ''
   errorCountOfAlcohol: string = ''
   errorIncome: string = ''
   errorProfit: string = ''


   /**
    * Валидация формы
    */
   valid: boolean = false  // флаг на валидацию формы

   /**
    * Переменные для radio input
    */
   genderRadio = [  // пол
      new IInputRadioModel(1,'man', 'Мужчина', true),
      new IInputRadioModel(2, 'woman', 'Женщина', false)
   ]
   handsRadio = [  // рабочая рука
      new IInputRadioModel(1,'right', 'Правша', true),
      new IInputRadioModel(2, 'left', 'Левша', false)
   ]

   selectedRadio: IInputRadioModel = null  // активный radio

   /**
    * Регулярки
    */
   nameRegex: RegExp = /^[A-zА-я\s^_][^0-9\s_]+$/; //'[\\w\s]+';  // имя
   phoneRegex: RegExp = /^(\s*)?(\+)?([- _():+]?\d[- _():+]?){8,14}(\s*)?$/;  // телефон
   numberRegex: RegExp = /^[0-9]+$/


   created() {}


   /**
    * Выбор текущего значения input radio
    */
   onSelected(current: IInputRadioModel) {
      this.selectedRadio = current
   }


   /**
    * Валидация формы
    */
   isValid(event: any) {
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

      /* patronymic */
      if (this.patronymic == '' || this.patronymic == undefined) {
         this.errorPatronymic = 'Это обязательное поле'
         this.valid = false
      } else if (!this.nameRegex.test(this.patronymic)) {
         this.errorPatronymic = 'Введите корректое отчество'
         this.valid = false
      } else {
         this.errorPatronymic = '';
         this.valid = true
      }

      /* pasport series */
      if (this.pasportSeries == '' || this.pasportSeries == undefined) {
         this.errorPasportSeries = 'Это обязательное поле'
         this.valid = false
      }  else {
         this.errorPasportSeries = '';
         this.valid = true
      }

      /* pasport number */
      if (this.pasportNumber == '' || this.pasportNumber == undefined) {
         this.errorPasportNumber = 'Это обязательное поле'
         this.valid = false
      }  else {
         this.errorPasportNumber = '';
         this.valid = true
      }

      /* ИНН */
      if (this.inn == null || this.inn == 0 || this.inn == undefined) {
         this.errorInn = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.inn)) {
         this.errorInn = 'Введите корректный ИНН'
         this.valid = false
      } else {
         this.errorInn = '';
         this.valid = true
      }

      /* Дата рождения */
      if (this.dateOfBurth == '' || this.dateOfBurth == undefined) {
         this.errorDateOfBurth = 'Это обязательное поле'
         this.valid = false
      }  else {
         this.errorDateOfBurth = '';
         this.valid = true
      }

      /* Полных лет */
      if (this.age == null || this.inn == 0 || this.age == undefined) {
         this.errorAge = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.age)) {
         this.errorAge = 'Введите корректный возраст'
         this.valid = false
      } else if (this.age >= 100) {
         this.errorAge = 'Введите корректный возраст'
         this.valid = false
      } else {
         this.errorAge = '';
         this.valid = true
      }
      
      /* Семейное положение */
      if (this.maritalStatus == '' || this.maritalStatus == undefined) {
         this.errorMaritalStatus = 'Это обязательное поле'
         this.valid = false
      } else if (!this.nameRegex.test(this.maritalStatus)) {
         this.errorMaritalStatus = 'Введите корректное семейное положение'
         this.valid = false
      } else {
         this.errorMaritalStatus = '';
         this.valid = true
      }

      /* Девичья фамилия */
      

      /* Место работы */
      if (this.placeOfWork == '' || this.placeOfWork == undefined) {
         this.errorPlaceOfWork = 'Это обязательное поле'
         this.valid = false
      } else {
         this.errorPlaceOfWork = '';
         this.valid = true
      }

      /* Должность */
      if (this.position == '' || this.position == undefined) {
         this.errorPosition = 'Это обязательное поле'
         this.valid = false
      } else {
         this.errorPosition = '';
         this.valid = true
      }

      /* Служебные обязанности */
      if (this.responsibilities == '' || this.responsibilities == undefined) {
         this.errorResponsibilities = 'Это обязательное поле'
         this.valid = false
      } else {
         this.errorResponsibilities = '';
         this.valid = true
      }

      /* Кол-во финансово зависимых людей */
      if (this.addictedPeople == null || this.inn == 0 || this.addictedPeople == undefined) {
         this.errorAddictedPeople = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.addictedPeople)) {
         this.errorAddictedPeople = 'Введите число'
         this.valid = false
      } else {
         this.errorAddictedPeople = '';
         this.valid = true
      }

      /* Место проживания */
      if (this.placeOfResidence == '' || this.placeOfResidence == undefined) {
         this.errorPlaceOfResidence = 'Это обязательное поле'
         this.valid = false
      } else {
         this.errorPlaceOfResidence = '';
         this.valid = true
      }

      /* Адрес для корреспонденции */
      if (this.addressMail == '' || this.addressMail == undefined) {
         this.errorAddressMail = 'Это обязательное поле'
         this.valid = false
      } else {
         this.errorAddressMail = '';
         this.valid = true
      }

      /* Почтовый индекс */
      if (this.index == null || this.inn == 0 || this.index == undefined) {
         this.errorIndex = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.index)) {
         this.errorIndex = 'Введите число'
         this.valid = false
      } else {
         this.errorIndex = '';
         this.valid = true
      }

      /* Рост */
      if (this.height == null || this.inn == 0 || this.height == undefined) {
         this.errorHeight = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.height)) {
         this.errorHeight = 'Введите число'
         this.valid = false
      } else {
         this.errorHeight = '';
         this.valid = true
      }

      /* Вес */
      if (this.weight == null || this.inn == 0 || this.weight == undefined) {
         this.errorWeight = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.weight)) {
         this.errorWeight = 'Введите число'
         this.valid = false
      } else {
         this.errorWeight = '';
         this.valid = true
      }

      /* Кол-во сигарет в день */
      if (this.countOfCigarettes == null || this.inn == 0 || this.countOfCigarettes == undefined) {
         this.errorСountOfCigarettes = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.countOfCigarettes)) {
         this.errorСountOfCigarettes = 'Введите число'
         this.valid = false
      } else {
         this.errorСountOfCigarettes = '';
         this.valid = true
      }

      /* Кол-во алкоголя день */
      if (this.countOfAlcohol == null || this.inn == 0 || this.countOfAlcohol == undefined) {
         this.errorCountOfAlcohol = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.countOfAlcohol)) {
         this.errorCountOfAlcohol = 'Введите число'
         this.valid = false
      } else {
         this.errorCountOfAlcohol = '';
         this.valid = true
      }

      /* Совокупный доход */
      if (this.income == null || this.inn == 0 || this.income == undefined) {
         this.errorIncome = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.income)) {
         this.errorIncome = 'Введите число'
         this.valid = false
      } else {
         this.errorIncome = '';
         this.valid = true
      }

      /* Чистый доход */
      if (this.profit == null || this.inn == 0 || this.profit == undefined) {
         this.errorProfit = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.profit)) {
         this.errorProfit = 'Введите число'
         this.valid = false
      } else {
         this.errorProfit = '';
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


   /**
    * Клик по чекбоксу мотоциклист
    */
   setMotorcyclist() {
      this.motorcyclist = !this.motorcyclist
   }

}


</script>

<style scoped>

.take-a-program-form {
   padding: 20px;
   display: grid;
   grid-template-columns: repeat(3, 1fr);
   grid-template-rows: auto;
   column-gap: 15px;
   row-gap: 21px;
   border-radius: 20px;
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.1);
}



/* radio group */
.radio-group,
.checkbox-wrap {
   grid-column: 1 / 4;
   width: max-content;
}


/* Dancing */
.i-title.dancing {
   margin-bottom: 15px;
   font-family: 'Dancing Script', cursive;
   font-size: 50px;
   font-weight: 700;
   color: #12be83;
   text-align: center;
   position: relative;
   z-index: 1;
   text-transform: none;
}

/* Заголовок в форме */
.i-title.form-title {
   margin-bottom: 40px;
   font-size: 25px;
   font-weight: 700;
   line-height: 120%;
   color: #fff;
   text-align: center;
   position: relative;
   z-index: 1;
}




/* phone */
.phone-wrap {
   width: 100%;
   position: relative;
   z-index: 1;
}


@media all and (max-width: 991px) {
   .take-a-program-form { grid-template-columns: repeat(2, 1fr); }
   .radio-group, .checkbox-wrap { grid-column: 1 / 2; }
}

@media all and (max-width: 620px) {
   .take-a-program-form { grid-template-columns: repeat(1, 1fr); }
   .radio-group, .checkbox-wrap { grid-column: 1 / 1; }
}

@media all and (max-width: 450px) {
   .i-title.form-title { font-size: calc((100vw - 280px)/(450 - 280) * (25 - 20) + 20px); }
}

@media all and (max-width: 340px) {
   .take-a-program-form { padding: 20px 7px; }
}
</style>

<style>

.phone-wrap .form-item input {
   padding-left: 115px;
}
</style>