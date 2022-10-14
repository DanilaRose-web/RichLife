<template>
   <div class="chat-form">
      <div class="grid-item">
         <i-new-input 
            ref="name"
            v-model="name"
            :name="'name'"
            :placeholder="'Ivan'"
            :required="true"
            :regex="nameRegex"
            light
            showError
            isStandart />
      </div>

      <div class="grid-item">
         <i-new-input 
            ref="surname"
            v-model="surname"
            :name="'surname'"
            :placeholder="'Ivanov'"
            :required="true"
            :regex="nameRegex"
            light
            showError
            isStandart />
      </div>

      <div class="grid-content">
         <div class="grid-item flex-item phone-item">
            <i-new-input 
               class="phone"
               ref="phone"
               v-model="phone"
               :name="'phone'"
               :placeholder="'565 556 56 65'"
               :required="true"
               :regex="phoneRegex"
               light
               showError
               isPhone>
               <langs-dropdown @selectedItem="onSelectedCodeNumber" :isPhone="true" :absolute="true"></langs-dropdown>
            </i-new-input>
         </div>
      </div>

      <div class="grid-item">
         <i-new-input 
            ref="email"
            v-model="email"
            :name="'email'"
            :placeholder="'example@gmail.com'"
            :required="true"
            :regex="emailRegex"
            light
            showError
            isStandart />
      </div>

      <div class="grid-item">
         <i-textarea 
            ref="message"
            v-model="message"
            :name="'message'"
            :placeholder="'Напишите Ваш вопрос'"
            :required="true"
            light
            showError />
      </div>

      <i-button @onClick="isValidationClick" :height="'45px'" :fontSize="'16px'" :padding="'13px 25px'" >Отправить</i-button>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

import LangsModel from "@components/langs-dropdown/models/LangsModel";

@Component
export default class ChatFormComponent extends Vue {

   /**
    * Переменные - v-model инпутов
    */
   name: string = ''  // value имя
   surname: string = ''  // value фамилия
   message: string = ''  // сообщение
   phone: string = ''  // телефон
   email: string = ''  // email

   selectedCodeNumber: LangsModel = null

   /**
    * Регулярки
    */
   nameRegex: RegExp = /^[A-zА-я\s^_][^0-9\s_]+$/; //'[\\w\s]+'; // имя
   phoneRegex: RegExp = /^(\s*)?(\+)?([- _():+]?\d[- _():+]?){8,14}(\s*)?$/; // телефон
   emailRegex: RegExp = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/ // email 



   /**
    * Валидация формы
    */
   isValidationClick() {
      console.log(this.GetRef('name').value);
      
      if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) &&
         // (this.GetRef('surname') && !this.GetRef('surname').checkValidation()) && 
         (this.GetRef('email') && !this.GetRef('email').checkValidation()) &&
         (this.GetRef('phone') && !this.GetRef('phone').checkValidation()) &&
         (this.GetRef('message') && !this.GetRef('message').checkValidation())
      ) {
         
      } else if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) ||
         // (this.GetRef('surname') && !this.GetRef('surname').checkValidation()) || 
         (this.GetRef('email') && !this.GetRef('email').checkValidation()) ||
         (this.GetRef('phone') && !this.GetRef('phone').checkValidation()) ||
         (this.GetRef('message') && !this.GetRef('message').checkValidation())
      ) {
         
      } else {
         this.sendRegisterRequest()
      }
   }

   /**
    * Выбранный Код страны
    */
   onSelectedCodeNumber(selectedLang: LangsModel) {
      this.selectedCodeNumber = selectedLang
      console.log(this.selectedCodeNumber, 'selectedCodeNumber');
   }


   /**
    * SendMessageRequest - отправка письма на почту
    */
   sendRegisterRequest() {
      var self = this

      var settings = {
         "url": "http://31.31.24.200:5051/Account/SendMessage",
         "method": "POST",
         "timeout": 0,
         "processData": false,
         "mimeType": "multipart/form-data",
         "headers": {
            "accept": "application/json",
            "Content-Type": "application/json"
         },
         "data": JSON.stringify({
            "name": this.name,
            "surName": this.surname,
            "phone": this.phone,
            "codeNumber": this.selectedCodeNumber.CodeNumber,
            "email": this.email,
            "message": this.message,
            "emailFrom": "wellbelife1@gmail.com"
         }),
      };
      $.ajax(settings).done(function (response) {
         console.log(response, 'response');
         self.$emit('close')
         // var user = new Function( 'return (' + response + ')' )();me: 'sign' })
         // if (user) {
         //    self.user = user
         // }
      });
   }
}
</script>

<style scoped>

.chat-form {
   padding: 20px;
   display: grid;
   grid-template-columns: 1fr;
   grid-template-rows: auto;
   row-gap: 10px;
}
</style>