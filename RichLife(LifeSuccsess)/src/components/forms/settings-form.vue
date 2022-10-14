<template>
   <div class="settings-form-wrap">

      <!-- Общие настройки -->
      <div class="additional-settings settings-form-block">
         <h3 class="form-block-title">Общие настройки</h3>

         <div class="image-block">
            <div class="set-image">
               <image-preview-modal v-if="!imageUpload"
                  ref="crop" 
                  v-model="image" 
                  :one-image=true
                  :aspect-ratio=170/170 
                  :el-hight=170 @input="addImg" 
               />
               
               <div class="crop-wrap" v-if="imageArray">
                  <div class="crop-content">
                     <div class="close" @click="removeInnerImage()">
                        <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-close"></use></svg>
                     </div>
                     <crop-image-preview
                        id="crop_preview"
                        ref="croppreview"
                        :el-height="170"
                        :crop-params="imageArray.cropImg"
                        :aspect-ratio="170 / 170">
                     </crop-image-preview>
                  </div>
               </div> 
            </div>

            <div class="image-info">
               <div class="h3 image-title">Редактируйте фото</div>
               <p class="image-text">Нажмите на иконку слева, чтобы добавить фото</p>
               <p class="image-text">Если вы уже добавили фото и хотите изменить, нажмите на "крестик" над фото, затем снова на иконку</p>
            </div>
         </div>

         <transition name="fadeThanks" mode="out-in">
            <div class="form-wrap" v-if="!thanksBlockProfile">
               <div class="settings-form" key="1">
                  <div class="grid-item">
                     <i-new-input
                        @changeValue="changeValue" 
                        ref="name"
                        v-model="name"
                        :name="'name'"
                        :placeholder="'Имя'"
                        :label="'Имя'"
                        :required="true"
                        :regex="nameRegex"
                        showError
                        isStandart
                        greyBorder
                        hasLabel
                     >
                        <template slot="tooltip">Введите Имя латинскими буквами, как в загран паспорте (рекомендуется). Так как эти данные можно буде использовать для упрощения процедуры оформления программы</template>
                     </i-new-input>
                  </div>
               
                  <div class="grid-item">
                     <i-new-input
                        @changeValue="changeValue" 
                        ref="email"
                        v-model="email"
                        :name="'email'"
                        :placeholder="'example@gmail.com'"
                        :label="'Email'"
                        :required="true"
                        :regex="emailRegex"
                        showError
                        isStandart
                        greyBorder
                        hasLabel
                     >
                        <template slot="tooltip">Указывайте ТОЛЬКО gmail (Google-почта)</template>
                     </i-new-input>
                  </div>

                  <div class="grid-item column100">
                     <i-button @onClick="onAddPhone">{{ btnTitle }}</i-button>
                  </div>

                  <transition name="fadePhone">
                     <div class="grid-item column100 fade-grid-item" v-if="addPhone">
                        <i-new-input
                           @changeValue="changeValue" 
                           class="phone"
                           ref="phone"
                           v-model="phone"
                           :name="'phone'"
                           :placeholder="'565 556 56 65'"
                           :label="'Телефон'"
                           :required="true"
                           :regex="phoneRegex"
                           showError
                           isPhone
                           greyBorder
                           hasLabel>
                           <langs-dropdown @selectedItem="onSelectedCodeNumber" isPhone absolute withInputLabel></langs-dropdown>
                           <template slot="tooltip">Укажите номер телефона без кода страны. Если номер ПМР, то введите его в формате: 779 123 45</template>
                        </i-new-input>
                     </div>
                  </transition>
               </div>
            </div>

            <div class="thanks-block fade-block" v-if="thanksBlockProfile" key="2">
               <h1 class="i-title thank-you-title">Данные профиля изменены!</h1>
               <p class="i-text thank-you-text">Данные профиля успешно изменены! Чтобы вернуться к редактированию профиля, нажмите на кнопку ниже</p>

               <div class="button-wrap">
                  <i-button @onClick="closeThanksBlock" class="green">Вернуться к редактированию</i-button>
               </div>
            </div>
         </transition>

      </div>

      <i-button :class="{'disable' : disable}" :height="'max-content'" @onClick="changeDisable" :fontSize="'16px'" :padding="'13px 25px'" :maxWidth="'170px'">Сохранить</i-button>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

import ImagePreviewModel from "@components/i-crop-image/ImagePreviewModel"
import UserModel from "../../models/UserModel";

import cookie from "js-cookie"
import LangsModel from "@components/langs-dropdown/models/LangsModel";

@Component
export default class SettingsFormComponent extends Vue {

   @Prop({ type: Object, default: null }) user: UserModel // пользователь

   /**
    * Переменные - v-model инпутов
    */
   name: string = ''  // имя
   email: string = ''  // email
   phone: string = ''  // phone

   selectedCodeNumber: LangsModel = null


   /**
    * Отключение кнопки "Сохранить изменения", если ничего не редактировалось
    */
   disable: boolean = true  // флаг на разблокирование кнопки сохранить при изменении инпутов

   thanksBlockProfile: boolean = false // флаг об успешном изменении профиля

   /**
    * Регулярки
    */
   nameRegex: RegExp = /^[A-zА-я\s^_][^0-9\_]+$/; //'[\\w\s]+';  // имя
   phoneRegex: RegExp = /^(\s*)?(\+)?([- _():+]?\d[- _():+]?){8,14}(\s*)?$/;  // телефон
   emailRegex: RegExp = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/ // email

   /**
    * Переменные для изменения фото (i-crop-image)
    */
   imageUpload: boolean = false // удаление кнопки "Добавить фото" при добавленной картинки
   imageArray: {cropImg:ImagePreviewModel, fileName: string} = null
   image: ImagePreviewModel = null

   /**
    * Прочее
    */
   addPhone: boolean = false  // флаг на добавление телефона
   btnTitle: string = 'Добавить телефон'  // текст конпки добавить/удалить номер телефона



   @Watch('user') changeUser() {
      console.log(this.user, 'user');
      if (this.user) {
         this.name = this.user.Name
         this.email = this.user.Email
         if (this.user.Phone != '' || this.user.Phone != null) {
            this.phone = this.user.Phone
            this.addPhone = true
            this.btnTitle = "Удалить телефон"
         } 
      }
   }

   @Watch('addPhone') changeAddPhone() {
      console.log(this.user, 'user');
      if (!this.addPhone) {
         this.selectedCodeNumber.CodeNumber = ''
         this.phone = ''
         this.disable = false
      }
   }

   created() {
   }

   /**
    * Выбранный Код страны
    */
   onSelectedCodeNumber(selectedLang: LangsModel) {
      this.selectedCodeNumber = selectedLang
      console.log(this.selectedCodeNumber, 'selectedCodeNumber');
   }


   /**
    * Добавление/удаление поля с номером телефона
    */
   onAddPhone() {
      this.addPhone = !this.addPhone
      if (this.addPhone) 
         this.btnTitle = "Удалить телефон"
         else this.btnTitle = "Добавить телефон"
   }

   /**
    * Отправляем форму, если значение интпутов изменилось
    */
   changeDisable() {
      if (!this.disable) 
         this.isValidationClick()
   }
 


   /**
    * Добавление картинки в массив 
    */
   addImg(image: ImagePreviewModel, fileName:string) {
      this.imageUpload = true
      this.imageArray = {cropImg: image, fileName: fileName}
      // console.log(fileName, 'fileName');
   }

   /**
    * Удаление выбранной картинки
    */
   removeInnerImage() {
      this.imageUpload = false // добавление конпки "Добавить Фото", после того, как картинка была удалена
      this.imageArray = null // key - уникальный параметр картинки. splice(кликнутый элемент, сколько элементов удалить)
   }


   /**
    * Валидация формы
    */
   isValidationClick() {
      if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) &&
         (this.GetRef('email') && !this.GetRef('email').checkValidation()) &&
         (this.GetRef('phone') && !this.GetRef('phone').checkValidation()) 
      ) {} 
      else if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) ||
         (this.GetRef('email') && !this.GetRef('email').checkValidation()) ||
         (this.GetRef('phone') && !this.GetRef('phone').checkValidation()) 
      ) {} 
      else { 
         console.log('форма отправилась');
         this.thanksBlockProfile = true
         // this.updateUser()
      }
   }

   /**
    * Разблокирование кнопки сохранить при изменении значений инпутов
    */
   changeValue() {
      this.disable = false
      console.log(this.name, 'name');
      
   }

   /**
    * Метод редактирования пользователя
    */
   // updateUser() {
   //    var self = this

   //    var settings = {
   //       "url": "http://31.31.24.200:5051/Account/UpdateUser",
   //       "method": "POST",
   //       "timeout": 0,
   //       "headers": {
   //          "Authorization": "Bearer " + cookie.get('token'),
   //          "accept": "application/json",
   //          "Content-Type": "application/json"
   //       },
   //       "processData": false,
   //       "data": JSON.stringify({
   //          "userId": self.user.Id,
   //          "name": self.name,
   //          "email": self.email,
   //          "phone": self.phone,
   //          "codeCountry": self.selectedCodeNumber.CodeNumber
   //       })
   //    };

   //    $.ajax(settings).done(function (response) {
   //       // var localStorageUser: UserModel = JSON.parse(localStorage.getItem('user'))
   //       var user: UserModel = new UserModel(
   //          self.user.Id,
   //          self.user.Token,
   //          self.name ? self.name : self.user.Name,
   //          self.email ? self.email : self.user.Email,
   //          self.phone ? self.phone : self.user.Phone,
   //          self.selectedCodeNumber.CodeNumber ? self.selectedCodeNumber.CodeNumber : self.user.CodeCountry,
   //          self.user.IsAdmin,
   //          self.user.TookTheProgram,
   //          self.user.RefferalLink
   //       )

   //       localStorage.setItem('user', JSON.stringify(user))
   //       self.thanksBlockProfile = true
   //    }); 
   // }

   /**
    * Скрытие блока об успешном изменении данных профиля
    */
   closeThanksBlock() {
      this.thanksBlockProfile = false
   }

}


</script>

<style scoped>

/* thank you block */
.thanks-block {
   margin: 30px auto;
}

.thank-you-title {
   text-transform: none;
   font-size: 30px;
   color: #121B23;
}

.thank-you-text {
   margin: 15px auto;
   font-size: 17px;
   text-align: center;
   color: #121B23;
   max-width: 500px;
}

.fadeThanks-enter-active, .fadeThanks-leave-active {
   transition: all 0.3s ease-out;
}

.fadeThanks-enter, .fadeThanks-leave-to {
   opacity: 0;
   visibility: hidden;
}




.settings-form-wrap {
   margin: 0 auto;
   max-width: 900px;
}

.settings-form-block {
   margin-bottom: 30px;
   border-radius: 20px;
   border: 1px solid #e6e6eb;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.form-block-title {
   padding: 20px;
   font-size: 20px;
   font-weight: 600;
   line-height: 120%;
   color: #121B23;
   border-bottom: 1px solid #e6e6eb;
}

.settings-form {
   padding: 30px 20px;
   display: grid;
   grid-template-columns: 1fr 1fr;
   grid-template-rows: auto;
   gap: 20px;
}

.grid-item.column100 {
   grid-column: 1/3;
}

.fade-grid-item {
   opacity: 1;
   visibility: visible;
   transform: translateX(0);
}

.fadePhone-enter-active, .fadePhone-leave-active {
   transition: all 0.3s ease-out;
}
.fadePhone-enter, .fadePhone-leave-to {
   opacity: 0;
   visibility: hidden;
   transform: translateX(10px);
}



/* CROP-IMAGE
========================================================================================= */
.image-block {
   margin: 20px 0;
   display: flex;
   align-items: center;
}

.image-info {
   margin: 0 20px;
}

.image-title {
   margin-bottom: 20px;
   font-size: 20px;
   font-weight: 600;
   line-height: 120%;
   color: #121B23;
}

.image-text {
   margin-bottom: 10px;
   font-size: 14px;
   font-weight: 500;
   line-height: 130%;
   color: #121B23;
   max-width: 500px;
}

.set-image {
   margin: 0 20px;
   width: 170px;
}

.crop-wrap {
   display: flex;
   justify-content: center;
}

.crop-content {
   position: relative;
   width: max-content;
   border-radius: 50%;
}

.close {
   position: absolute;
   right: 15px;
   top: 0;
   width: 30px;
   height: 30px;
   display: flex;
   align-items: center;
   justify-content: center;
   background: #12be83;
   border-radius: 50%;
   box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
   z-index: 2;
   cursor: pointer;
   transition: all 0.2s ease-out;
}

.close svg {
   width: 17px;
   height: 17px;
   fill: #fff;
   transition: all 0.2s ease-out;
}

.close:hover {
   background: #FACDD4;
}

.close:hover svg {
   fill: #121B23;
}



@media all and (max-width: 680px) {
   .form-block { grid-template-columns: 1fr; gap: 10px; }
   .form-item-flex { grid-column: 1 / 2; }
}

@media all and (max-width: 500px) {
   .image-block { flex-direction: column; align-items: center; }
   .image-info { margin: 20px; }
   .image-title, .image-text { text-align: center; }
}

@media all and (max-width: 450px) {
   .form-block { padding: 20px 10px; }
}

</style>

<style>

.phone-wrap .form-item input {
   padding-left: 115px;
}
</style>