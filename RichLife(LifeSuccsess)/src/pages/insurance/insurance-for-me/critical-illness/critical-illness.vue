<template>

   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch">
      <template slot="header">
         <minimal-header-metlife @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />

         <!-- <services-static-menu>
            <ul class="static-menu">
               <li><router-link to="life-insurance">Страхование жизни</router-link></li>
               <li><router-link to="insurance-accident">Страхование от несчастных случаев</router-link></li>
               <li class="active"><router-link to="critical-illness">Страхование в случае критических заболеваний</router-link></li>
               <li><router-link to="">Женское страхование</router-link></li>
            </ul>
         </services-static-menu> -->
      </template>

      <breadcrumbs>
         <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <router-link to="metlife">MetLife <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <!-- <router-link to="insurance-for-me">Страхование для меня <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link> -->
         <span>Страхование в случае критических заболеваний</span>
      </breadcrumbs>

      <section class="section-main i-section">
         <i-container>
            <span class="i-title dancing">Critical Accident</span>
            <h1 class="i-title section-title">Защита при серьезной болезни</h1>
            <h4 class="i-subtitle">Финансовая помощь при серьезной болезни – уникальные возможности для решения финансовых проблем в случае даигностирования серьезной болезни, которые помогут сохранить Ваш привычный уровень жизни.</h4>
         
            <h3 class="static-md-title">Финансовая помощь при серьезной болезни</h3>
            
            <div class="descr-wrap">
               <div class="descr-block">
                  <p>«Здоровье не купишь, оно бесценно» — мы с детства помним эту народную мудрость, но так ли это? </p>
               </div>
               <div class="descr-block">
                  <p>Обладая необходимыми средствами, любой человек может значительно улучшить свое здоровье, восстановить его, спасти свою жизнь. Сегодня можно вылечить почти любую болезнь, а если не вылечить — свести к минимуму всю негативную симптоматику и продолжать жить обычной комфортной жизнью. Но даже если у человека есть возможность выделить из бюджета необходимую для лечения сумму, это будут непредсказуемые и не запланированные расходы. В результате это сократит привычные статьи затрат, заставит отказаться от своих планов по покупке тех или иных товаров и услуг и, как следствие, скорее всего, снизит уровень комфорта жизни человека.</p>
               </div>
               <div class="descr-block">
                  <p>МетЛайф предлагает лучшие решения, помогающие в решении финансовых проблем, связанных с ухудшением состояния здоровья вследствие серьезных болезней и их лечением, сохраняя при этом привычный уровень жизни и компенсируя затраты на лечение клиента.</p>
               </div>
            </div>

            <div class="navigate-block">
               <div class="navigate-row row">
                  <div class="col-6 navigate-col">
                     <router-link to="program-c-1" class="navigate-link">
                        <div class="watermark">01</div>
                        <h3>Программа страхования СИ-1</h3>
                        <p>Постоянная нетрудоспособность в результате несчастного Страхование на случай диагностирования у Застрахованного Лица критического заболевания</p>
                     </router-link>
                  </div>
                  <div class="col-6 navigate-col">
                     <router-link to="program-c-7" class="navigate-link">
                        <div class="watermark">02</div>
                        <h3>Программа страхования СИ-7</h3>
                        <p>Страхование на случай диагностирования у Застрахованного Лица 1 из 7 критических заболеваний</p>
                     </router-link>
                  </div>
                  <div class="col-6 navigate-col">
                     <router-link to="program-c-32" class="navigate-link">
                        <div class="watermark">03</div>
                        <h3>Программа страхования СИ-32</h3>
                        <p>Страхование на случай диагностирования у Застрахованного Лица 1 из 32 критических заболеваний/состояний</p>
                     </router-link>
                  </div>
                  <div class="col-6 navigate-col">
                     <router-link to="program-w" class="navigate-link">
                        <div class="watermark">04</div>
                        <h3>Программа страхования W</h3>
                        <p>Страхование на случай постоянной и полной нетрудоспособности страхователя (освобождение от уплаты страховых премий)</p>
                     </router-link>
                  </div>
               </div>
            </div>
         </i-container>
      </section>

      <!-- Форма регистрации -->
      <i-modal :contentMaxWidth="'600px'" :show="showJoinModal" @close="onHideJoinModal" >
         <join-form></join-form>
      </i-modal>

      <!-- Модалка проверки авторизации -->
      <i-modal :contentMaxWidth="'600px'" :show="noteGetInTouch" @close="noteGetInTouch = false">
         <notification-get-in-touch @click="onShowJoinModal"></notification-get-in-touch>
      </i-modal>

      <!-- Форма "Оставить заявку" -->
      <i-modal :contentMaxWidth="'600px'" :show="getInTouch" @close="getInTouch = false">
         <get-in-touch></get-in-touch>
      </i-modal>

      <modal-chat :innerOpen="openChat" @closeChat="onCloseChat"></modal-chat>
   </layout>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

import cookie from "js-cookie"

@Component
export default class PageCriticalIllnessComponents extends Vue {  // Страница - Страхование от несчастных случаев

   showJoinModal: boolean = false  // флаг на открытие формы join
   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false
   noteGetInTouch: boolean = false // фдаг на открытие окна с проверкой на авторизацию


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
      this.noteGetInTouch = false
      this.$emit('showJoin', this.showJoinModal)
   }

   /**
    * Закрытие модального окна с формой join
    */
   onHideJoinModal() {
      this.showJoinModal = false
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

   /**
    * Открытие модального окна с проверкой на авторизацию
    */
   openNoteModal() {
      this.noteGetInTouch = true
   }

   /**
    * Открытие модалки на проверку авторизации, при клике на "Оставить заявку"
    */
   onGetInTouch() {
      if (cookie.get('token') == '' || cookie.get('token') == undefined) {
         this.noteGetInTouch = true
      } else {
         this.getInTouch = true
      }
   }

}
</script>

<style scoped>

.static-md-title {
   margin: 70px auto 0 auto;
   font-size: 20px;
   font-weight: 700;
   line-height: 140%;
   color: #121B23;
   text-align: center;
   max-width: 900px;
}

.descr-wrap {
   margin: 0 auto;
   max-width: 1000px;
}

.descr-block {
   margin-top: 60px;
   padding: 20px;
   position: relative;
   background: #F8F9FC;
   border-radius: 15px;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.descr-block::before {
   content: '';
   position: absolute;
   top: -30px;
   left: -30px;
   width: 70px;
   height: 70px;
   background: url('/assets/img/backgrounds/dots-bg.webp') no-repeat center;
   background-size: cover;
   z-index: -1;
}

.descr-block p {
   font-size: 15px;
   font-weight: 500;
   line-height: 150%;
   color: #121B23;
}





.navigate-block {
   margin: 100px auto 0 auto;
   max-width: 1000px;
}


.navigate-col {
   margin-bottom: 30px;
   display: flex;
}

.navigate-link {
   padding: 20px;
   display: flex;
   flex-direction: column;
   align-items: center;
   width: 100%;
   position: relative;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
   border-radius: 15px;
   transition: all 0.2s ease-out;
}

.navigate-link .watermark {
   position: absolute;
   top: 5px;
   left: 5px;
   font-size: 100px;
   font-weight: 700;
   color: rgba(18, 190, 131, 0.1);
   transition: all 0.2s ease-in-out;
}

.navigate-link h3 {
   margin-bottom: 15px;
   font-size: 19px;
   font-weight: 700;
   color: #121B23;
   line-height: 140%;
   text-align: center;
   transition: all 0.2s ease-out;
}

.navigate-link p {
   font-size: 15px;
   font-weight: 500;
   line-height: 140%;
   color: #121B23;
   text-align: center;
}

.navigate-link:hover {
   transform: translateY(-7px);
}

.navigate-link:hover .watermark {
   color: rgba(250, 205, 212, 0.3);
}

.navigate-link:hover h3 {
   color: #12be83;
}



@media all and (max-width: 590px) {
   .navigate-col { flex: 0 0 100%; max-width: 100%; }
}
</style>