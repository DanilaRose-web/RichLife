<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch">
      <template slot="header">
         <minimal-header-metlife @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />

         <!-- <services-static-menu>
            <ul class="static-menu">
               <li><router-link to="life-insurance">Страхование жизни</router-link></li>
               <li><router-link to="insurance-accident">Страхование от несчастных случаев</router-link></li>
               <li><router-link to="critical-illness">Страхование в случае критических заболеваний</router-link></li>
               <li><router-link to="womens-insurance">Женское страхование</router-link></li>
            </ul>
         </services-static-menu> -->
      </template>

      <breadcrumbs>
         <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <router-link to="metlife">MetLife <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <span>Страхование для меня</span>
      </breadcrumbs>

      <section class="section-for-me i-section">
         <i-container>
            <span class="i-title dancing">For Me</span>
            <h1 class="i-title section-title">Страхование для меня</h1>
            <h5 class="i-subtitle">Надежная комплексная защита для вас на случай неприятных, но вполне вероятных ситуаций в жизни.</h5>
         
            <div class="for-me-row row">
               <div class="for-me-col col-12 col-sm-12 col-md-6 col-lg-4 col-xl-4">
                  <div class="item">
                     <router-link to="" class="img">
                        <picture>
                           <source media="(max-width: 660px)" srcset="/assets/img/insurance/for-me/for-me-sm1.webp">
                           <img src="/assets/img/insurance/for-me/for-me-lg1.webp" alt="Защитите свое здоровье">
                        </picture>
                     </router-link>
                     <div class="item-info">
                        <router-link class="i-title sm-title for-me-title" to=""><h4>Защитите свое здоровье</h4></router-link>
                        <p class="i-text for-me-text">Надежную комплексную защиту на случай неприятных, но вполне вероятных ситуаций в жизни. Мы не всегда можем это предотвратить, но мы способны защитить себя и своих дорогих людей от негативных последствий таких событий.</p>
                        <router-link class="link-btn" to="">Подробнее</router-link>
                     </div>
                  </div>
               </div>

               <div class="for-me-col col-12 col-sm-12 col-md-6 col-lg-4 col-xl-4">
                  <div class="item">
                     <router-link to="" class="img">
                        <picture>
                           <source media="(max-width: 660px)" srcset="/assets/img/insurance/for-me/for-me-sm2.webp">
                           <img src="/assets/img/insurance/for-me/for-me-lg2.webp" alt="Обеспечьте свое будущее">
                        </picture>
                     </router-link>
                     <div class="item-info">
                        <router-link class="i-title sm-title for-me-title" to=""><h4>Обеспечьте свое будущее</h4></router-link>
                        <p class="i-text for-me-text">Компания «МетЛайф» предлагает комплексные решения для накоплений к определенному событию, альтернативного пенсионного обеспечения и защиты вашей жизни.</p>
                        <router-link class="link-btn" to="">Подробнее</router-link>
                     </div>
                  </div>
               </div>
               
               <div class="for-me-col col-12 col-sm-12 col-md-6 col-lg-4 col-xl-4">
                  <div class="item">
                     <router-link to="" class="img">
                        <picture>
                           <source media="(max-width: 660px)" srcset="/assets/img/insurance/for-me/for-me-sm3.webp" >
                           <img src="/assets/img/insurance/for-me/for-me-lg3.webp" alt="Специальные предложения">
                        </picture>
                     </router-link>
                     <div class="item-info">
                        <router-link class="i-title sm-title for-me-title" to=""><h4>Специальные предложения</h4></router-link>
                        <p class="i-text for-me-text">Забота о клиентах - это смысл существования и кропотливой работы в течение 152 лет во всем мире и в течение 18 последних лет в Украине в частности. Именно поэтому мы предлагаем особую предложение с постоянной скидкой от обычного тарифа.</p>
                        <router-link class="link-btn" to="">Подробнее</router-link>
                     </div>
                  </div>
               </div>

               <div class="for-me-col col-12 col-sm-12 col-md-6 col-lg-12 col-xl-12">
                  <div class="item item-flex">
                     <router-link to="" class="img img-flex">
                        <picture>
                           <source media="(max-width: 660px)" srcset="/assets/img/insurance/for-me/metLife-sm.webp" >
                           <img src="/assets/img/insurance/for-me/metLife-lg.webp" alt="Компания страхования жизни MetLife">
                        </picture>
                     </router-link>
                     <div class="item-info item-info-flex">
                        <router-link class="i-title sm-title for-me-title mb" to=""><h4>Компания страхования жизни MetLife</h4></router-link>
                        <p class="i-text for-me-text">Более <strong>152 лет</strong> в мире и <strong>18 лет</strong> в Украине.</p>
                        <p class="i-text for-me-text">Более <strong>90 000 000</strong> клиентов в мире.</p>
                        <p class="i-text for-me-text">Более <strong>759 000</strong> клиентов в Украине.</p>
                        <p class="i-text for-me-text strong">Мы знаем о страховании жизни и здоровья все!</p>
                        <router-link class="link-btn" to="">Подробнее</router-link>
                     </div>
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
export default class PageInsuranceForMeComponents extends Vue {

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

.for-me-col {
   margin-bottom: 30px;
   display: flex;
}

.item {
   display: flex;
   flex-direction: column;
   align-items: center;
   border-radius: 15px;
   overflow: hidden;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
   transition: all 0.3s ease-out;
}

.item .img {
   position: relative;
   overflow: hidden;
   transition: all 0.3s ease-out;
}

.item .img img {
   max-width: 100%;
   height: auto;
   transition: all 0.3s ease-out;
}

.item .img::after {
   content: '';
   position: absolute;
   top: 0;
   left: 0;
   width: 100%;
   height: 100%;
   background: #12be83;
   opacity: 0;
   visibility: hidden;
   transition: all 0.2s ease-out;
}

.item:hover {
   transform: translateY(-7px);
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.3);
}

.item:hover .img::after {
   opacity: 0.5;
   visibility: visible;
}



.item-info {
   margin-top: 15px;
   padding: 20px;
   display: flex;
   flex-direction: column;
   align-items: center;
   justify-content: space-between;
   flex: 1 1 auto;
}

.for-me-title {
   line-height: 115%;
   transition: all 0.2s ease-out;
}

.for-me-title:hover {
   color: #12be83;
}

.for-me-text {
   margin: 20px 0 30px 0;
   font-size: 15px;
   font-weight: 500;
   line-height: 140%;
   text-align: center;
}

.for-me-text strong {
   font-weight: 700;
}

.item-info .link-btn {
   margin: 0px auto;
   padding: 10px 20px;
   display: flex;
   align-items: center;
   justify-content: center;
   border-radius: 28px;
   font-family: inherit;
   font-weight: 600;
   font-size: 15px;
   background: #12be83;
   color: #fff;
   transition: all 0.3s ease-out 0s;
}

.item-info .link-btn:hover {
   background: #0da671;
}


/* блок с MetLife */
.item-flex {
   flex-direction: row;
}

.img-flex {
   flex: 0 0 50%;
   max-width: 50%;
}

.item-info-flex {
   flex: 0 0 50%;
   max-width: 50%;
   justify-content: center;
}

.item-info-flex p {
   margin: 0 0 10px 0;
}

.item-info-flex p.strong {
   margin-bottom: 30px;
   font-weight: 700;
   color: #12be83;
}

.for-me-title.mb {
   margin-bottom: 20px;
}


@media all and (max-width: 992px) {
   .item-flex { flex-direction: column; }
   .img-flex, .item-info-flex { max-width: 100%; flex: auto; }
   .item-info-flex { flex: 1 1 auto; }
}

@media all and (max-width: 340px) {
   .item-info { padding: 15px 10px; }
   .for-me-title { font-size: 22px; }
   .for-me-text { font-size: 14px; }
}

</style>