<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter">
      <template slot="header">
         <minimal-header-home @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />
      </template>

      <i-container>
         <congrates></congrates>
         <broker-request @click="openModal"></broker-request>

         <div class="tabs-wrap">
            <div class="tabs">
               <div class="tab" 
                  v-for="(tab, index) in tabs.tabArray" :key="index"
                  @click="tabs.activeTab = tab"
                  :class="{'active' : tabs.activeTab === tab}">
                     <span>{{ tab }}</span>
               </div>
            </div>

            <div class="content-wrap">
               <div class="tab-content" v-if="tabs.activeTab === 'Контракты'">
                  <i-table :data="iTableData"></i-table>
                  <div class="pagination-wrap">
                     <i-pagination></i-pagination>
                  </div>
               </div>
               <div class="tab-content" v-if="tabs.activeTab === 'Структура'">
                  <h3 class="tab-content-title">Структура в данный момент находится в разработке...</h3>
                  
               </div>
            </div>
         </div>
      </i-container>
      
      <i-modal :show="showBrokerRequestModal" @close="closeModal" >
         <transition name="fadeThanks" mode="out-in">
            <div class="form-wrap" v-if="!showThanks" key="1">
               <broker-request-form @success="thanks"></broker-request-form>
            </div>
            <div class="thanks-for-send" v-if="showThanks" key="2">
               <p class="thanks-text">Ваша заявка отправлена брокеру на рассмотрение. Как только она будет одобрена, мы с Вами свяжемся</p>
               <p class="thanks-text dancing">Спасибо! Хорошего дня и отличного настроения</p>
            </div>
         </transition>
         
      </i-modal>

      <i-modal :show="showJoinModal" @close="onHideJoinModal" >
         <div class="review-video">
            <join-form></join-form>
         </div>
      </i-modal>
   </layout>
</template>

<script lang="ts">

import Vue from "vue";
import { Component, Prop } from "vue-property-decorator";

import ITableData from "@components/i-table/models/ITableData";

@Component
export default class PageProfileComponent extends Vue {

   tabs: object = null  // иницифализируем табы
   iTableData: ITableData[] = []  // модель таблицы

   showBrokerRequestModal: boolean = false // флаг отображения модального окна
   showJoinModal: boolean = false  // флаг на открытие формы join forn

   name: string = ''  // value имя
   surname: string = ''  // value фамилия
   email: string = ''  // value email
   phone: string = ''  // value phone

   /* регулярки */
   nameRegex: RegExp = /^[A-zА-я\s^_][^0-9\s_]+$/; //'[\\w\s]+';  // имя
   phoneRegex: RegExp = /^(\s*)?(\+)?([- _():+]?\d[- _():+]?){11,14}(\s*)?$/;  // телефон

   showThanks: boolean = false  // показываем блок "спасибо", когда форма отправлена

   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false


   created() {
      this.createdTabs()
      this.createITableData()
   }

   mounted() {
      
   }

   /**
    * Тестирование данных для таблицы
    */
   createITableData() {
      this.iTableData = [
         new ITableData(1, 123456, '12.04.1996', 'Danila Rose', 200, 20000, 200000),
         new ITableData(2, 123456, '12.04.1996', 'Епифанова Наталья Алексеевна', 10000, 105649, 200000),
         new ITableData(3, 123456, '12.04.1996', 'Епифанова Наталья Алексеевна', 10000, 105649, 200000),
         new ITableData(4, 123456, '12.04.1996', 'Епифанова Наталья Алексеевна', 10000, 105649, 200000),
         new ITableData(5, 123456, '12.04.1996', 'Епифанова Наталья Алексеевна', 10000, 105649, 200000),
         new ITableData(6, 123456, '12.04.1996', 'Епифанова Наталья Алексеевна', 10000, 105649, 200000)
      ]
   }

   /**
    * Вкладки
    */
   createdTabs() {
      this.tabs = {
         tabArray: ['Контракты', 'Структура'],
         activeTab: 'Контракты'
      }
   }

   /**
    * Открытие модального окна c broker request form
    */
   openModal() {
      this.showBrokerRequestModal = true
   }

   /**
    * Закрытие модального окна c broker request form
    */
   closeModal() {
      this.showBrokerRequestModal = false
      this.showThanks = false
   }


   /**
    * Emit, который передает значение флага для открытия формы join из layout (т.к. layout-footer инициализируется в layout, а не на этой странице)
    */
   onShowJoinModalFooter(showJoinModalFooter: boolean) {
      this.showJoinModal = showJoinModalFooter
   }

   /**
    * Открытие модального окна с формой join
    */
   onShowJoinModal() {
      this.showJoinModal = true
      this.$emit('showJoin', this.showJoinModal)
   }

   /**
    * Закрытие модального окна с формой join
    */
   onHideJoinModal() {
      this.showJoinModal = false
   }

   thanks() {
      this.showThanks = true
   }

   /**
    * Окрытие окна с чатом при клике на "связаться с нами" из services-menu
    */
   onCallUs() {
      this.openChat = true
      this.innerShowMenu = false
   }

   onChangeShow(show: boolean) {
      this.innerShowMenu = show
   }

   /**
    * Передача флага open: false, из компонента modal-chat при закрытии чата
    */
   onCloseChat(open: boolean) {
      this.openChat = open
   }
   
}
</script>

<style scoped>

.tabs-wrap {
   margin: 70px 0 100px 0;
   border-radius: 20px;
   box-shadow: 0 0 16px 0 rgba(190, 190, 204, 0.4);
   background: #fff;
}

.tabs {
   display: flex;
   align-items: center;
   overflow: hidden;
   background: #F8F9FC;
   border-radius: 20px;
}

.tabs .tab {
   background: transparent;
   width: 50%;
   font-size: 20px;
   font-weight: 700;
   color: #000;
   position: relative;
   cursor: pointer;
   box-shadow: 0 0 16px 0 rgba(190, 190, 204, 0.1);
}


/* активная вкладка */
.tabs .tab.active {
   background: #fff;
   border-top-left-radius: 20px;
   border-top-right-radius: 20px;
   box-shadow: none;
   z-index: 2;
}


/* прямоугольники */
.tabs .tab.active::after,
.tabs .tab.active::before {
   content: '';
   position: absolute;
   bottom: 0;
   width: 40px;
   height: 23px;
   background: #fff;  
}

.tabs .tab.active::after {
   right: -30px;
}

.tabs .tab.active::before {
   left: -30px;
}




/* круги */
.tabs .tab span {
   padding: 15px;
   display: flex;
   position: relative;
   z-index: 2;
   justify-content: center;
}

.tabs .tab.active span::after,
.tabs .tab.active span::before {
   content: '';
   position: absolute;
   width: 55px;
   height: 55px;
   bottom: 0;
   border-radius: 50%;
   z-index: 1;
   background: #F8F9FC;
}

.tabs .tab.active span::after {
   right: -55px;
}

.tabs .tab.active span::before {
   left: -55px;
}







/* tab-content */


.tab-content {
   border-radius: 20px;
   background: #fff;
}

.tab-content-title {
   padding: 20px 10px;
   font-size: 17px;
   font-weight: 500;
   line-height: 140%;
   color: #121B23;
   text-align: center;
}




.pagination-wrap {
   padding: 40px 15px 15px 15px;
}




@media all and (max-width: 540px) {
   .tabs-wrap { padding-top: 15px; }
   .tabs { flex-direction: column; align-items: center; }
   .tabs .tab { width: 100%; order: 1; background: #12be83; border-top-left-radius: 20px; border-top-right-radius: 20px; }
   .tabs .tab.active { order: 2; margin-top: -15px; }
   .tabs .tab span { padding-bottom: 30px; }
   .tabs .tab.active::after,
   .tabs .tab.active::after,
   .tabs .tab.active span::after,
   .tabs .tab.active span::before { display: none; }
}












/* i-form */
.form-item-flex {
   display: flex;
   align-items: center;
}

/* Dancing */
.i-title.dancing {
   margin-bottom: 10px;
   font-family: 'Dancing Script', cursive;
   font-size: 50px;
   font-weight: 700;
   color: #FF2626;
   text-align: center;
   position: relative;
   z-index: 1;
}

/* Заголовок в форме */
.i-title.form-title {
   margin-bottom: 40px;
   font-size: 25px;
   font-weight: 500;
   line-height: 120%;
   color: #fff;
   text-align: center;
   position: relative;
   z-index: 1;
}





/* блок "спасибо" */
.thanks-for-send {
   display: flex;
   flex-direction: column;
   align-items: center;
   opacity: 1;
   visibility: visible;
}

.thanks-text {
   margin-bottom: 20px;
   font-size: 16px;
   font-weight: 600;
   line-height: 140%;
   color: #fff;
   text-align: center;
   max-width: 600px;
}

.thanks-text.dancing {
   font-family: 'Astrum', cursive;
   font-size: 25px;
   line-height: 90%;
   color: #12be83;
   text-align: center;
}

.fadeThanks-enter-active, .fadeThanks-leave-active {
   transition: all 0.3s ease-out;
}

.fadeThanks-enter, .fadeThanks-leave-to {
   opacity: 0;
   visibility: hidden;
}




@media all and (max-width: 660px) {
   .form-item-flex { flex-direction: column; align-items: flex-start; }
   .i-button.form-btn { order: 2; }
   .checkbox { margin: 15px 0 30px 0; order: 1; }
}

@media all and (max-width: 450px) {
   .i-title.form-title { font-size: calc((100vw - 280px)/(450 - 280) * (25 - 20) + 20px); }
}

</style>