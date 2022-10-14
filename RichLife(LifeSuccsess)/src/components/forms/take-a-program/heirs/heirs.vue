<template>
   <div class="heirs-wrap" >
      <transition-group name="fadeHeir">
         <div class="heir" v-for="(item, index) in arrayHeirs" :key="item.Id">
            <div class="title-wrap">
               <h3 class="heirs-title">Наследник {{ index + 1 }}</h3>
               <svg v-if="notFirstEl" @click="deleteHeir(item.Id)"><use xlink:href="/assets/img/svg-sprite.svg#icon-close"></use></svg>
            </div>

            <div class="grid-content">
               <div class="grid-item" ref="grid">
                  <i-input 
                     :label="'Имя'"
                     v-model="item.Name"
                     :error="item.ErrorName"
                     :placeholder="'Имя'"
                     :name="'name'"
                     :regex="nameRegex"
                     :border="'1px solid rgba(18, 27, 35, 0.2)'"
                     hasTooltip
                     hasLabel
                     required >
                  </i-input>
               </div>

               <div class="grid-item">
                  <i-input 
                     :label="'Фамилия'"
                     v-model="item.Surname" 
                     :error="item.ErrorSurname"
                     :placeholder="'Фамилия'"
                     :name="'surname'"
                     :regex="nameRegex"
                     :border="'1px solid rgba(18, 27, 35, 0.2)'"
                     hasLabel
                     required />
               </div>

               <div class="grid-item">
                  <i-input 
                     :label="'Отчество'"
                     v-model="item.Patronymic" 
                     :error="item.ErrorPatronymic"
                     :placeholder="'Отчество'"
                     :name="'patronymic'"
                     :regex="nameRegex"
                     :border="'1px solid rgba(18, 27, 35, 0.2)'"
                     hasLabel
                     required />
               </div>

               <div class="grid-item">
                  <i-input 
                     :label="'Дата рождения'"
                     v-model="item.DateOfBirth" 
                     :error="item.ErrorDateOfBirth"
                     :placeholder="'12.04.1996'"
                     :name="'dateOfBurth'"
                     :border="'1px solid rgba(18, 27, 35, 0.2)'"
                     hasLabel
                     required />
               </div>

               <div class="grid-item">
                  <i-input 
                     :label="'Степень родства'"
                     v-model="item.RelationDegree" 
                     :error="item.ErrorRelationDegree"
                     :placeholder="'дочь, сын, отец'"
                     :name="'relationDegree'"
                     :border="'1px solid rgba(18, 27, 35, 0.2)'"
                     hasLabel
                     required />
               </div>

               <div class="grid-item">
                  <i-input 
                     :label="'Адрес'"
                     v-model="item.Address" 
                     :error="item.ErrorAddress"
                     :placeholder="'Адрес'"
                     :name="'address'"
                     :border="'1px solid rgba(18, 27, 35, 0.2)'"
                     required
                     hasLabel />
               </div>

               <div class="grid-item column100">
                  <i-input 
                     :label="'% Выплаты'"
                     v-model="item.PayoutPercentAge" 
                     :error="item.ErrorPayoutPercentAge"
                     :regex="numberRegex"
                     :placeholder="'% Выплаты'"
                     :name="'payoutPercentAge'"
                     :border="'1px solid rgba(18, 27, 35, 0.2)'"
                     required
                     hasLabel />
               </div>
            </div>
         </div>
      </transition-group>
      
      <!-- Кнопка для добавления нового (пустого) блока "Наследник" -->
      <div class="grid-item column100">
         <div class="add-heir-btn" @click="addHeir">
            <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-plus"></use></svg>
            <span>Добавить наследника</span>
         </div>
      </div>

      <div class="grid-item item-btn">
         <i-button @onClick="$emit('prev')" class="transparent" :margin="'0 10px 0 0'">Назад</i-button>
         <i-button @onClick="isValid">Оформить</i-button>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Watch } from "vue-property-decorator"

import HeirsModel from "./HearsModel"

@Component
export default class HeirsComponent extends Vue {

   /**
    * Переменные наследников
    */
   arrayHeirs: HeirsModel[] = []  // массив наследников
   heir: HeirsModel = null  // наследник
   heirId: number = 0

   name: string = ''
   surname: string = ''
   patronymic: string = ''
   dateOfBirth: string = ''
   relationDegree: string = ''
   address: string = ''
   payoutPercentAge: number = null


   errorName: string = ''
   errorSurname: string = ''
   errorPatronymic: string = ''
   errorDateOfBirth: string = ''
   errorRelationDegree: string = ''
   errorAddress: string = ''
   errorPayoutPercentAge: string = ''

   valid: boolean = false
   notFirstEl: boolean = false

   /**
    * Регулярные выражения
    */
   nameRegex: RegExp = /^[A-zА-я\s^_][^0-9\s_]+$/; //'[\\w\s]+';  // имя
   numberRegex: RegExp = /^[0-9]+$/ // только числа

   /**
    * Отслеживаем изменения массива с наследниками и через emit
    * передаем модель с наследниками HearsModel в компонент step-five
    */
   @Watch('arrayHeirs') change() {
      if (this.arrayHeirs.length == 1) 
         this.notFirstEl = false
         else this.notFirstEl = true
   }

   created() {
      this.addHeir()
   }

   /**
    * Добавление наследника
    */
   addHeir() {
      this.heirId++
      this.heir = new HeirsModel(
         this.heirId, 
         this.name, 
         this.surname, 
         this.patronymic,
         this.dateOfBirth,
         this.relationDegree,
         this.address,
         this.payoutPercentAge,

         this.errorName, 
         this.errorSurname,
         this.errorPatronymic,
         this.errorDateOfBirth,
         this.errorRelationDegree,
         this.errorAddress,
         this.errorPayoutPercentAge
      )
      this.arrayHeirs.push(this.heir)
   }

   /**
    * Удаление наследника
    */
   deleteHeir(id: number) {
      let selecterHeir = this.arrayHeirs.findIndex(el => el.Id == id)
      this.arrayHeirs.splice(selecterHeir, 1)
   }
  


   isValid(event: any) {
      this.arrayHeirs.forEach(item => {

         /* Имя */
         if (item.Name == '' || item.Name == undefined) {
            item.ErrorName = 'Это обязательное поле'
            this.valid = false
         } else if (!this.nameRegex.test(item.Name)) {
            item.ErrorName = 'Введите корректное имя'
            this.valid = false
         } else {
            item.ErrorName = '';
            this.valid = true
         }

         /* Фамилия */
         if (item.Surname == '' || item.Surname == undefined) {
            item.ErrorSurname = 'Это обязательное поле'
            this.valid = false
         } else if (!this.nameRegex.test(item.Surname)) {
            item.ErrorSurname = 'Введите корректную фамилию'
            this.valid = false
         } else {
            item.ErrorSurname = '';
            this.valid = true
         }


         /* Отчество */
         if (item.Patronymic == '' || item.Patronymic == undefined) {
            item.ErrorPatronymic = 'Это обязательное поле'
            this.valid = false
         } else if (!this.nameRegex.test(item.Patronymic)) {
            item.ErrorPatronymic = 'Введите корректное отчество'
            this.valid = false
         } else {
            item.ErrorPatronymic = '';
            this.valid = true
         }

         /* Дата рождения */
         if (item.DateOfBirth == '' || item.DateOfBirth == undefined) {
            item.ErrorDateOfBirth = 'Это обязательное поле'
            this.valid = false
         }  else {
            item.ErrorDateOfBirth = '';
            this.valid = true
         }

         /* Степень родства */
         if (item.RelationDegree == '' || item.RelationDegree == undefined) {
            item.ErrorRelationDegree = 'Это обязательное поле'
            this.valid = false
         } else if (!this.nameRegex.test(item.RelationDegree)) {
            item.ErrorRelationDegree = 'Цифры недопустимы'
            this.valid = false
         } else {
            item.ErrorRelationDegree = '';
            this.valid = true
         }

         /* Адрес */
         if (item.Address == '' || item.Address == undefined) {
            item.ErrorAddress = 'Это обязательное поле'
            this.valid = false
         }  else {
            item.ErrorAddress = '';
            this.valid = true
         }

         /* % Выплаты */
         if (item.PayoutPercentAge == null || item.PayoutPercentAge == undefined) {
            item.ErrorPayoutPercentAge = 'Это обязательное поле'
            this.valid = false
         } else if (!this.numberRegex.test(item.PayoutPercentAge)) {
            item.ErrorPayoutPercentAge = 'Буквы недопустимы'
            this.valid = false
         } else {
            item.ErrorPayoutPercentAge = '';
            this.valid = true
         }

      })

      
      if (this.valid) {
         this.$emit('send', this.arrayHeirs)
         this.$router.push({ name: 'thank-you' })
      } else {
         console.log('форма 6 не отправилась');
      }

      
   }
}
</script>

<style scoped>

.heirs-wrap {
   margin-top: 30px;
}

.heir {
   opacity: 1;
   visibility: visible;
   transform: translateY(0);
}

.fadeHeir-enter-active, .fadeHeir-leave-active {
   transition: all 0.4s ease-out;
}

.fadeHeir-enter, .fadeHeir-leave-to {
   opacity: 0;
   visibility: hidden;
   transform: translateY(-5%);
}

.heir:not(:last-child) {
   margin-bottom: 30px;
}

.add-heir-btn {
   margin: 20px auto 0 auto;
   display: flex;
   align-items: center;
   justify-content: center;
   width: max-content;
   font-size: 14px;
   font-weight: 500;
   color: #121B23;
   cursor: pointer;
   transition: all 0.2s ease-out;
}

.add-heir-btn svg {
   margin-right: 10px;
   width: 20px;
   height: 20px;
   fill: #121B23;
   transition: all 0.2s ease-out;
}

.add-heir-btn:hover {
   color: #12be83;
}

.add-heir-btn:hover svg {
   fill: #12be83;
}


.item-btn {
   margin-top: 30px;
   width: 100%;
   grid-column: 1/3;
   display: flex;
   justify-content: flex-end;
}


.title-wrap {
   margin-bottom: 10px;
   padding-bottom: 10px;
   display: flex;
   align-items: center;
   justify-content: space-between;
   /* border-bottom: 1px solid #12be83; */
}

.title-wrap svg {
   width: 20px;
   height: 20px;
   fill: #121B23;
   cursor: pointer;
   transition: all 0.2s ease-out;
}

.title-wrap svg:hover {
   fill: #12be83;
}

.heirs-title {
   font-size: 20px;
   font-weight: 700;
   color: #121B23;
}

.grid-content {
   display: grid;
   grid-template-columns: 1fr 1fr;
   grid-template-rows: auto;
   gap: 15px;
}

.column100 {
   grid-column: 1/3;
}


@media all and (max-width: 620px) {
   .step-form { grid-template-columns: 1fr; }
   .item-btn { grid-column: 1/2; }
}

</style>
