<template>
   <div class="get-in-touch-wrap">
      <transition name="fadeThanks" mode="out-in">
         <div class="form-wrap fade-block" v-if="!thanksBlock" key="1">
            <!-- <h4 class="i-title dancing">Get in Touch</h4> -->
            <h4 class="i-title form-title">Заявка</h4>
            <h5 class="i-subtitle get-in-touch-subtitle">на предварительный расчет программы</h5>
            
            <!-- <invite-referal allWidth :color="'#fff'" alignCenter  :withButton="false"></invite-referal> -->

            <div class="get-in-touch-form">
               <div class="grid-item">
                  <i-new-input 
                     ref="name"
                     v-model="name"
                     :name="'name'"
                     :placeholder="'Имя'"
                     :required="true"
                     :regex="nameRegex"
                     showError
                     isStandart
                  ></i-new-input>
               </div>

               <div class="grid-item">
                  <i-new-input 
                     ref="dateOfBirth"
                     v-model="dateOfBirth"
                     :name="'dateOfBirth'"
                     :placeholder="'Дата рождения'"
                     :required="true"
                     showError
                     isStandart
                  ></i-new-input>
               </div>

               <div class="radio-group grid-item column100">
                  <i-input-radio @onSelected="onSelectedGender" :array="genderRadioYou" ></i-input-radio>
               </div>

               <div class="grid-item">
                  <i-new-input 
                     ref="profession"
                     v-model="profession"
                     :name="'profession'"
                     :placeholder="'Ваша профессия в настоящее время'"
                     :required="true"
                     showError
                     isStandart
                  ></i-new-input>
               </div>

               <div class="grid-item">
                  <div class="flex-item-content">
                     <div class="item-title no-wrap">Желаемый срок действия (лет):</div>
                     <div class="item-block">
                        <i-input-radio @onSelected="onSelectedValidity" :array="validityRadio" ></i-input-radio>
                     </div>
                  </div>
                  <transition name="fadeGrid">
                     <div class="amount-wrap" v-if="selectedValidity && selectedValidity.id == 'иное'">
                        <i-new-input 
                           ref="validity"
                           v-model="validity"
                           :name="'validity'"
                           :placeholder="'Срок действия (лет)'"
                           :required="true"
                           :regex="numberRegex"
                           showError
                           isStandart
                        ></i-new-input>
                     </div>
                  </transition>
               </div>

               <div class="grid-item">
                  <div class="flex-item-content">
                     <div class="item-title">Как вы оцениваете состояние своего здоровья, были ли у Вас критические заболевания?</div>
                     <div class="item-block">
                        <i-input-radio @onSelected="onSelectedDisease" :array="diseaseRadio" ></i-input-radio>
                     </div>
                  </div>
                  <transition name="fadeGrid">
                     <div class="amount-wrap" v-if="selectedDisease && selectedDisease.id == 'yes'">
                        <i-new-input 
                           ref="disease"
                           v-model="disease"
                           :name="'disease'"
                           :placeholder="'Укажите критические заболевания'"
                           :required="true"
                           showError
                           isStandart
                        ></i-new-input>
                     </div>
                  </transition>
               </div>

               <div class="grid-item">
                  <div class="flex-item-content">
                     <div class="item-title no-wrap">Годовой взнос ($):</div>
                     <div class="item-block">
                        <i-input-radio @onSelected="onSelectedProgramAmount" :array="programAmountRadio" ></i-input-radio>
                     </div>
                  </div>
                  <transition name="fadeGrid">
                     <div class="amount-wrap" v-if="selectedProgramAmount && selectedProgramAmount.id == 'иное'">
                        <i-new-input 
                           ref="programAmount"
                           v-model="programAmount"
                           :name="'programAmount'"
                           :placeholder="'Годовой взнос ($)'"
                           :required="true"
                           :regex="numberRegex"
                           showError
                           isStandart
                        ></i-new-input>
                     </div>
                  </transition>
               </div>

               <div class="grid-item">
                  <div class="flex-item-content">
                     <div class="item-title">Вы приняли решения взять прогармму для:</div>
                     <div class="item-block">
                        <i-input-radio @onSelected="onSelectedForWhom" :array="forWhom" ></i-input-radio>
                     </div>
                  </div>
               </div>

               <transition name="fadeGrid">
                  <div class="fade-grid-content" v-if="selectedRadioForWhom && selectedRadioForWhom.id != 'me'">
                     <div class="grid-item">
                        <i-new-input 
                           ref="nameAnother"
                           v-model="nameAnother"
                           :name="'nameAnother'"
                           :placeholder="'Имя ребенка/родственника/другого человека'"
                           :required="true"
                           :regex="nameRegex"
                           showError
                           isStandart
                        ></i-new-input>
                     </div>

                     <div class="grid-item">
                        <i-new-input 
                           ref="dateOfBirthAnother"
                           v-model="dateOfBirthAnother"
                           :name="'dateOfBirthAnother'"
                           :placeholder="'Дата рождения ребенка/родственника/другого человека'"
                           :required="true"
                           showError
                           isStandart
                        ></i-new-input>
                     </div>

                     <div class="radio-group grid-item column100">
                        <i-input-radio @onSelected="onSelectedAnother" :array="genderRadioAnother" ></i-input-radio>
                     </div>

                     <div class="grid-item">
                        <i-new-input 
                           ref="professionAnother"
                           v-model="professionAnother"
                           :name="'professionAnother'"
                           :placeholder="'Профессия в настоящее время'"
                           :required="true"
                           showError
                           isStandart
                        ></i-new-input>
                     </div>  

                     <div class="grid-item">
                        <div class="flex-item-content">
                           <div class="item-title">Как вы оцениваете состояние своего здоровья, были ли у Вас критические заболевания?</div>
                           <div class="item-block">
                              <i-input-radio @onSelected="onSelectedDiseaseAnother" :array="diseaseRadioAnother" ></i-input-radio>
                           </div>
                        </div>
                        <transition name="fadeGrid">
                           <div class="amount-wrap" v-if="selectedDiseaseAnother && selectedDiseaseAnother.id == 'yes'">
                              <i-new-input 
                                 ref="diseaseAnother"
                                 v-model="diseaseAnother"
                                 :name="'diseaseAnother'"
                                 :placeholder="'Укажите критические заболевания'"
                                 :required="true"
                                 showError
                                 isStandart
                              ></i-new-input>
                           </div>
                        </transition>
                     </div>
                  </div>
               </transition>


               <div class="grid-item flex-item phone-item">
                  <i-new-input 
                     class="phone"
                     ref="phone"
                     v-model="phone"
                     :name="'phone'"
                     :placeholder="'565 556 56 65'"
                     :required="true"
                     :regex="phoneRegex"
                     showError
                     isPhone>
                     <langs-dropdown @selectedItem="onSelectedCodeNumber" :isPhone="true" :absolute="true"></langs-dropdown>
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
                     showError
                     isStandart
                  ></i-new-input>
               </div>

               <div class="i-button-wrap">
                  <i-button @onClick="isValidationClick" :height="'45px'" :fontSize="'16px'" :padding="'13px 25px'" :maxWidth="'170px'">Отправить</i-button>
                  <div class="policy-confirm-wrap">
                     <div class="privacy-policy">
                        <p class="text">Нажимая на кнопку "Отправить" Вы соглашаетесь на обработку своих персональных данных, согласно условиям <a href="">политики конфиденциальности</a></p>
                     </div>
                  </div>
               </div>
            </div>
         </div>

         <div class="thanks-block fade-block" v-if="thanksBlock" key="2">
            <span class="i-title dancing">Thank you</span>
            <h1 class="i-title thank-you-title">Ваша заявка успешно отправлена!</h1>
            <p class="i-text thank-you-text">Мы произведем расчет программы на основании предоставленных данных и свяжемся с Вами в ближайшее время</p>

            <div class="button-wrap">
               <!-- <i-button :padding="'10px 25px 10px 25px'" @onClick="goToGmail">Открыть Gmail</i-button> -->
               <!-- <i-button @onClick="$emit('close')">Продолжить</i-button> -->
            </div>
         </div>
      </transition>
   </div>
</template>

<script lang="ts">
import IInputRadioModel from "@components/i-input-radio/IInputRadioModel";
import Vue from "vue";
import { Component } from "vue-property-decorator"

import cookie from "js-cookie"
import LangsModel from "@components/langs-dropdown/models/LangsModel";

@Component
export default class GetInTouchForm extends Vue {

   /**
    * Переменные inputs
    */
   name: string = '' // имя
   dateOfBirth: string = '' // дата рождения
   profession: string = ''  // профессия/род деятельности
   validity: number | string = null  // срок действия программы
   disease: string = '' // хронические заболевания/инвалидность
   programAmount: number | string = null // стоимость программы
   nameAnother: string = '' // имя другого человека
   dateOfBirthAnother: string = '' // дата рождения другого человека
   professionAnother: string = '' // профессия другого человека
   diseaseAnother: string = '' // хронические заболевания/инвалидность другого человека
   phone: string = '' // телефон
   email: string = '' // email
   selectedCodeNumber: LangsModel = null

   /**
    * Переменные для radio input
    */
   genderRadioYou: IInputRadioModel[] = []  // выбор своего пола
   genderRadioAnother: IInputRadioModel[] = []  // выбор своего пола
   forWhom: IInputRadioModel[] = []  // для кого программа
   programAmountRadio: IInputRadioModel[] = [] // годовой взнос
   diseaseRadio: IInputRadioModel[] = [] // критические заболевания
   diseaseRadioAnother: IInputRadioModel[] = [] // критические заболевания другого человека
   validityRadio: IInputRadioModel[] = [] // срок действия программы

   selectedRadioGender: IInputRadioModel = { Id: 1, id: 'man', Label: 'Мужчина', Selected: true }  // активный radio - пол (свой)
   selectedRadioForWhom: IInputRadioModel = { Id: 1, id: 'me', Label: 'себя', Selected: true }  // активный radio - для кого программа
   selectedRadioAnother: IInputRadioModel = { Id: 1, id: 'man', Label: 'Мужчина', Selected: true }  // активный radio - пол (другого человека)
   selectedProgramAmount: IInputRadioModel = { Id: 2, id: 420, Label: 420, Selected: true, Recommended: true } // активный radio - годовой взнос программы
   selectedDisease: IInputRadioModel = { Id: 1, id: 'no', Label: 'нет', Selected: true } // активный radio - критические заболевания
   selectedDiseaseAnother: IInputRadioModel = { Id: 1, id: 'no', Label: 'нет', Selected: true } // активный radio - критические заболевания другого человека
   selectedValidity: IInputRadioModel = { Id: 1, id: 15, Label: 15, Selected: true } // активный radio - срок дейстяи программы

   thanksBlock: boolean = false

   /**  
    * Регулярки
    */
   nameRegex: RegExp = /^[A-zА-я\s^_][^0-9\_]([A-zА-я\s^_]+)+$/; //'[\\w\s]+';  // имя
   phoneRegex: RegExp = /^(\s*)?(\+)?([- _():+]?\d[- _():+]?){8,14}(\s*)?$/;  // телефон
   emailRegex: RegExp = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/ // email 
   numberRegex: RegExp = /^[0-9]+$/ // только числа
   nameRegexLat: RegExp = /^\w+[^0-9\s\_]([- _]\w+)*$/ // имя на литинском  

   /**
    * Другие переменные
    */
   showThanksBlock: boolean = false // показываем блок спасибо после успешной отправки формы

   created() {
      this.genderRadioYou = [ 
         new IInputRadioModel(1,'man', 'Мужчина', true),
         new IInputRadioModel(2, 'woman', 'Женщина', false)
      ]

      this.forWhom = [
         new IInputRadioModel(1,'me', 'себя', true),
         new IInputRadioModel(2, 'child', 'ребенка', false),
         new IInputRadioModel(3, 'stranger', 'другого человека', false)
      ]

      this.genderRadioAnother = [
         new IInputRadioModel(1,'man', 'Мужчина', true),
         new IInputRadioModel(2, 'woman', 'Женщина', false)
      ]

      this.programAmountRadio = [
         new IInputRadioModel(1, 380, 380, false),
         new IInputRadioModel(2, 420, 420, true, true),
         new IInputRadioModel(3, 550, 550, false),
         new IInputRadioModel(4, 'иное', 'иное', false)
      ]
      
      this.validityRadio = [
         new IInputRadioModel(1, 15, 15, true),
         new IInputRadioModel(2, 20, 20, false),
         new IInputRadioModel(3, 25, 25, false),
         new IInputRadioModel(4, 'иное', 'иное', false)
      ]

      this.diseaseRadio = [ 
         new IInputRadioModel(1,'no', 'нет', true),
         new IInputRadioModel(2, 'yes', 'да', false)
      ]

      this.diseaseRadioAnother = [ 
         new IInputRadioModel(1,'no', 'нет', true),
         new IInputRadioModel(2, 'yes', 'да', false)
      ]

      if (this.selectedRadioForWhom.Id == 1) 
         this.selectedRadioAnother.Label = ''
      
      if (this.selectedRadioForWhom.Id == 1) 
         this.selectedDiseaseAnother.Label = ''
   }

   /**
    * Выбор текущего значения input radio
    */
   onSelectedGender(current: IInputRadioModel) {
      this.selectedRadioGender = current
      console.log(this.selectedRadioGender, 'selectedRadioGender');
   }

   onSelectedForWhom(current: IInputRadioModel) {
      this.selectedRadioForWhom = current
      console.log(this.selectedRadioForWhom, 'selectedRadioForWhom');
   }

   onSelectedAnother(current: IInputRadioModel) {
      this.selectedRadioAnother = current
      if (this.selectedRadioForWhom.Id == 1) 
         this.selectedRadioAnother.Label = ''
      
      console.log(this.selectedRadioAnother, 'selectedRadioAnother');
   }

   onSelectedProgramAmount(current: IInputRadioModel) {
      this.selectedProgramAmount = current
      this.programAmount = this.selectedProgramAmount.Label
      if (this.selectedProgramAmount.Id == 4) {
         this.programAmount = null
      }
      console.log(this.selectedProgramAmount, 'selectedProgramAmount');
   }

   onSelectedDisease(current: IInputRadioModel) {
      this.selectedDisease = current
      this.disease = this.selectedDisease.Label
      if (this.selectedDisease.Id == 2) 
         this.disease = null
      
      console.log(this.selectedDisease, 'selectedDisease');
   }

   onSelectedDiseaseAnother(current: IInputRadioModel) {
      this.selectedDiseaseAnother = current
      this.diseaseAnother = this.selectedDiseaseAnother.Label
      if (this.selectedDiseaseAnother.Id == 2) 
         this.diseaseAnother = null

      if (this.selectedRadioForWhom.Id == 1) 
         this.selectedDiseaseAnother.Label = ''
      
      
      console.log(this.selectedDiseaseAnother, 'selectedDiseaseAnother');
   }

   onSelectedValidity(current: IInputRadioModel) {
      this.selectedValidity = current
      this.validity = this.selectedValidity.Label
      if (this.selectedValidity.Id == 4) {
         this.validity = null
      }
      console.log(this.selectedValidity, 'selectedValidity');
   }

   /**
    * Выбранный Код страны
    */
   onSelectedCodeNumber(selectedLang: LangsModel) {
      this.selectedCodeNumber = selectedLang
   }


   isValidationClick() {
      if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) &&
         (this.GetRef('dateOfBirth') && !this.GetRef('dateOfBirth').checkValidation()) &&
         (this.GetRef('profession') && !this.GetRef('profession').checkValidation()) &&
         (this.GetRef('validity') && !this.GetRef('validity').checkValidation()) &&
         (this.GetRef('disease') && !this.GetRef('disease').checkValidation()) &&
         (this.GetRef('programAmount') && !this.GetRef('programAmount').checkValidation()) &&
         (this.GetRef('nameAnother') && !this.GetRef('nameAnother').checkValidation()) &&
         (this.GetRef('dateOfBirthAnother') && !this.GetRef('dateOfBirthAnother').checkValidation()) &&
         (this.GetRef('professionAnother') && !this.GetRef('professionAnother').checkValidation()) &&
         (this.GetRef('diseaseAnother') && !this.GetRef('diseaseAnother').checkValidation()) &&
         (this.GetRef('phone') && !this.GetRef('phone').checkValidation()) &&
         (this.GetRef('email') && !this.GetRef('email').checkValidation())
      ) {} 
      else if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) ||
         (this.GetRef('dateOfBirth') && !this.GetRef('dateOfBirth').checkValidation()) ||
         (this.GetRef('profession') && !this.GetRef('profession').checkValidation()) ||
         (this.GetRef('validity') && !this.GetRef('validity').checkValidation()) ||
         (this.GetRef('disease') && !this.GetRef('disease').checkValidation()) ||
         (this.GetRef('programAmount') && !this.GetRef('programAmount').checkValidation()) ||
         (this.GetRef('nameAnother') && !this.GetRef('nameAnother').checkValidation()) ||
         (this.GetRef('dateOfBirthAnother') && !this.GetRef('dateOfBirthAnother').checkValidation()) ||
         (this.GetRef('professionAnother') && !this.GetRef('professionAnother').checkValidation()) ||
         (this.GetRef('diseaseAnother') && !this.GetRef('diseaseAnother').checkValidation()) ||
         (this.GetRef('phone') && !this.GetRef('phone').checkValidation()) ||
         (this.GetRef('email') && !this.GetRef('email').checkValidation())
      ) {}
      else { 
         console.log('форма отправилась');
         this.sendRegisterRequest()
      }
   }

   sendRegisterRequest() {
      var self = this
      var settings = {
         "url": "http://31.31.24.200:5051/Account/GetInTouch",
         "method": "POST",
         "timeout": 0,
         "processData": false,
         "mimeType": "multipart/form-data",
         "headers": {
            "Authorization": "Bearer " + cookie.get('token'),
            "accept": "application/json",
            "Content-Type": "application/json"
         },
         "data": JSON.stringify({
            "name": self.name,  // имя
            "dateOfBirth": self.dateOfBirth, // дата рождения
            "gender": self.selectedRadioGender.Label, // пол
            "proffesion": self.profession, // профессия
            "validity": Number(self.validity), // срок действия программы
            "disease": self.disease, // критические заболевания
            "programAmount": Number(self.programAmount), // стоимость программы
            "forWhom": self.selectedRadioForWhom.Label, // для кого
            "nameOther": self.nameAnother, // имя другого человека
            "dateOfBirthOther": self.dateOfBirthAnother, // дата рождения другого человека
            "genderOther": self.selectedRadioAnother.Label, // пол другого человека
            "proffesionOther": self.professionAnother, // профессия другого человека
            "diseaseOther": self.diseaseAnother, // критические заболевания другого человека
            "phone": self.phone, // телефон
            "codeNumber": self.selectedCodeNumber.CodeNumber, // код страны (часть номера телефона - его значение засунуть в одно поле с значением телефона - /*codeNumber*/ /*phone*/ */)
            "email": self.email, // почта
            "emailFrom": 'wellbelife1@gmail.com'
         }),
      };
      $.ajax(settings).done(function (response) {
         console.log(response, 'response');
         self.thanksBlock = true
      });
   }
}
</script>

<style scoped>

/* thank you block */
.thank-you-title {
   text-transform: none;
   font-size: 23px;
   color: #fff;
}

.thank-you-text {
   margin-top: 15px;
   margin-bottom: 15px;
   font-size: 17px;
   text-align: center;
   color: #fff;
}

/* fade-block */
.fade-block {
   opacity: 1;
   visibility: visible;
}

.fadeThanks-enter-active, .fadeThanks-leave-active {
   transition: all 0.3s ease-out;
}

.fadeThanks-enter, .fadeThanks-leave-to {
   opacity: 0;
   visibility: hidden;
}


/* i-form */
.get-in-touch-form {
   display: grid;
   grid-template-columns: repeat(1, 1fr);
   grid-template-rows: auto;
   column-gap: 15px;
   row-gap: 21px;
   position: relative;
   z-index: 2;
}

.fade-grid-content {
   margin: 20px 0;
   display: grid;
   grid-template-columns: repeat(1, 1fr);
   grid-template-rows: auto;
   column-gap: 15px;
   row-gap: 21px;
   position: relative;
   opacity: 1;
   visibility: visible;
   transform: translateX(0);
}

.grid-item.flex-item {
   display: flex;
   align-items: center;
   width: 100%;
}

.grid-item.flex-item-start,
.flex-item-content {
   display: flex;
   flex-direction: column;
   align-items: center;
   width: 100%;
}

.item-title {
   margin-bottom: 10px;
   /* padding: 5px 10px; */
   font-size: 16px;
   font-weight: 600;
   line-height: 140%;
   color: #fff;
   user-select: none;
   text-align: center;
   border-radius: 28px;
   /* background: #fff; */
   width: 100%;
}

.item-title.no-wrap {
   white-space: nowrap;
}

.flex-item-content.column .item-title {
   margin-bottom: 10px;
}


/* radio group */
.radio-group {
   display: flex;
   justify-content: center;
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
   margin-bottom: 10px;
   font-size: 25px;
   font-weight: 700;
   line-height: 120%;
   color: #fff;
   text-align: center;
   position: relative;
   z-index: 1;
}

.get-in-touch-subtitle {
   font-size: 19px;
   font-weight: 500;
   line-height: 120%;
   color: #fff;
   text-align: center;
}



/* phone */
.phone-wrap {
   width: 100%;
   position: relative;
   z-index: 1;
}

.error-message {
   font-size: 15px;
   font-weight: 500;
   line-height: 140%;
   color: #eb2207;
   text-align: center;
}

.amount-wrap {
   margin-top: 10px;
   width: 100%;
   opacity: 1;
   visibility: visible;
   transform: translateX(0);
}



.i-button-wrap {
   display: flex;
   align-items: center;
   justify-content: space-between;
}




.fadeGrid-enter-active, .fadeGrid-leave-active {
   transition: all 0.3s ease-out;
}
.fadeGrid-enter, .fadeGrid-leave-to {
   opacity: 0;
   visibility: hidden;
   transform: translateX(20px);
}


@media all and (max-width: 660px) {
   .grid-item.column100 { grid-column: 1 / 2; }
   .i-button.form-btn { order: 2; }
   .checkbox { margin: 15px 0 30px 0; order: 1; }
}

@media all and (max-width: 600px) {
   .i-button-wrap { flex-direction: column; }
}

@media all and (max-width: 450px) {
   .i-title.form-title { font-size: calc((100vw - 280px)/(450 - 280) * (25 - 20) + 20px); }
}

</style>
