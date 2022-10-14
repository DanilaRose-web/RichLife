<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch"> 
      <template slot="header">
         <minimal-header-home @getInTouch="onGetInTouch" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="header-fixed" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />
      </template>

      <section class="section-main">
         <div class="video-wrap">
            <video id="main-video" loop muted autoplay poster="/uploads/video-bg-alt.jpg" class="fullscreen-bg__video">
               <source src="/assets/video/main-video2.mp4" type="video/mp4">
               <source src="/assets/video/main-video2.webm" type="video/webm">
               <source src="/assets/video/main-video2.ogv" type="video/ogv">
            </video>

            <div class="content-wrap">
               <i-container>
                  <h1>Будь уверен c <strong>WellbeLife</strong></h1>
                  <div class="i-button-group">
                     <div class="btn-wrap">
                        <i-button class="tt-u" @onClick="onGetInTouch">Оставить заявку</i-button>
                     </div>
                     <i-button class="orange tt-u" @onClick="showAboutModal = true">Смотреть видео</i-button>
                  </div>
               </i-container>
            </div>

            <svg><use xlink:href="/assets/img/svg-sprite.svg#wave"></use></svg>
         </div>
      </section>

      <services-menu @callUs="onCallUs" @onClick="onShowJoinModal"></services-menu>
      <!-- <invite-referal @onClick="onShowJoinModal" :inviteOnHighScreen="true" /> -->
      
      <section class="section-about i-section">
         <i-container>
            <i-button class="tt-u i-button-link" :margin="'0 auto'" @onClick="onGetInTouch">Оставить заявку</i-button>
            <!-- <h2 class="i-title section-title">О Нас</h2> -->
            <!-- <h6 class="i-subtitle">Мы собрали краткую информацию о себе в видео ниже</h6> -->
            <!-- <about-us></about-us> -->
         </i-container>
      </section>

      <!-- <section class="section-reviews i-section">
         <i-container>
            <h2 class="i-title section-title">Отзывы</h2>
            <h6 class="i-subtitle reviews-subtitle">Хотите узнать, что говорят о WellbeLife члены-партнёры нашего клуба? Посмотрите видеоотзывы ниже</h6>
            <reviews></reviews>
         </i-container>
      </section> -->

      <div class="useful-links-wrap">
         <useful-links @openNote="openNoteModal" @callUs="onCallUs"></useful-links>
      </div>

      <section class="section-partners" id="partners">
         <i-container>
            <h2 class="i-title section-title">Выбери своего партнера</h2>
            <h6 class="i-subtitle reviews-subtitle">Лидеры в страховании жизни, проверенные временем</h6>
            <partners></partners>
         </i-container>
      </section>
      
      <!-- Видно только после авторизации -->
      <div class="take-program">
         <i-button to="take-a-program" class="i-button-link tt-u" @onClick="onGetInTouch">Оставить заявку</i-button>
      </div>

      <!-- Форма регистрации -->
      <!-- <i-modal :contentMaxWidth="'600px'" :show="showJoinModal" @close="onHideJoinModal">
         <join-form @closeRegisterModal="onHideJoinModal"></join-form>
      </i-modal> -->

      <!-- Модальное окно "О нас" -->
      <i-modal :show="showAboutModal" @close="showAboutModal = false">
         <div class="about-video">
            <iframe height="400" src="https://www.youtube.com/embed/ypBj8dCtW8k" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
         </div>
      </i-modal>


      <i-modal :contentMaxWidth="'600px'" :show="getInTouch" @close="getInTouch = false">
         <get-in-touch></get-in-touch>
      </i-modal>

      <i-modal :contentMaxWidth="'600px'" :show="noteGetInTouch" @close="noteGetInTouch = false">
         <notification-get-in-touch @click="onShowJoinModal"></notification-get-in-touch>
      </i-modal>

      <modal-chat :innerOpen="openChat" @closeChat="onCloseChat"></modal-chat>
   </layout>
</template>  

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";

import cookie from "js-cookie"

@Component
export default class PageHomeComponent extends Vue {

   showJoinModal: boolean = false  // флаг на открытие формы join
   showAboutModal: boolean = false  // флаг на открытие модкльного окна "о нас"
   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false
   innerRegistered: boolean = false // флаг при успешной отправки формы welcome (для открытия доступа ссылок из services-menu)
   noteGetInTouch: boolean = false  // флаг на открытие модалки с notification перед открытием формы "Оставить заявку"



   mounted() {
      this.lasyMoveOnLinks()
      console.log(this.$route.name);
      
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
      this.noteGetInTouch = false
      this.$router.push({ name: 'register-referal' })
      // this.showJoinModal = true
      // this.$emit('showJoin', this.showJoinModal)
   }

   /**
    * Закрытие модального окна с формой join
    */
   // onHideJoinModal() {
   //    this.showJoinModal = false
   // }

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
    * Переопределяем флаг, когда была отправлена форма welcome
    */
   onReg(registered: boolean) {
      this.innerRegistered = registered
   }

   onGetInTouch() {
      if (cookie.get('token') == '' || cookie.get('token') == undefined) {
         this.noteGetInTouch = true
      } else {
         this.getInTouch = true
      }
   }

   /**
    * Открытие модального окна с проверкой на авторизацию
    */
   openNoteModal() {
      this.noteGetInTouch = true
   }

   /**
    * Плавный переход по ссылкам
    */
   lasyMoveOnLinks() {
      $(function () {
         $('a[href^="#"]').on('click', function (e) {
            e.preventDefault();
            $('.services-submenu li a, .mobile-submenu li a').removeClass('active').filter(this).addClass('active'); 
            var selector = $(this).attr('href'); 
            var h = $(selector);

            $('html, body').animate({
               scrollTop: h.offset().top - 60
            }, 1000);
         });
      });
   }
  
}
</script>

<style scoped>

.section-main {
   width: 100%;
   height: 100%;
   position: relative;
}

.i-button-group {
   display: flex;
   align-items: center;
   justify-content: flex-start;
   width: 100%;
}

.btn-wrap {
   margin-right: 15px;
}




/* video */
.video-wrap {
   margin: -5% 0;
   position: relative;
}

.section-about {
   padding-bottom: 0;
}

.about-video {
   width: 100%;
   height: 100%;
   border-radius: 10px;
   overflow: hidden;
}

.about-video iframe {
   width: 100%;
}

.video-wrap::after {
   content: '';
   position: absolute;
   top: 0;
   left: 0;
   width: 100%;
   height: 100%;
   background: rgba(0, 0, 0, 0.2);
}

#main-video {
   
   object-fit: cover;
   width: 100%;
}



/* svg section */
.section-main svg {
   fill: #F8F9FC;
   width: 100%;
   position: absolute;
   bottom: 0;
   left: 0;
   height: 10%;
   z-index: 2;
   transform: rotate(180deg);
}



.useful-links-wrap {
   margin-top: 60px;
}




/* content */
.content-wrap {
   position: absolute;
   top: 0;
   left: 0;
   width: 100%;
   height: 100%;
   display: flex;
   align-items: center;
   justify-content: flex-start;
   z-index: 1;
}

.content-wrap h1 {
   margin-top: 100px;
   margin-bottom: 50px;
   font-size: 80px;
   font-weight: 700;
   line-height: 105%;
   color: #fff;
   max-width: 620px;
   position: relative;
   z-index: 1;
}

.content-wrap h1 strong {
   color: #12be83;
   font-family: 'Fineday', cursive;
   font-weight: 500;
   font-size: 110px;
}


/* Ссылка на оформление программы */
.take-program {
   margin: 0 0 80px 0;
   width: 100%;
   display: flex;
   justify-content: center;
}

.reviews-subtitle {
   margin-top: 40px;
   font-weight: 600;
}

.section-partners {
   padding-bottom: 60px;
}




@media all and (max-width: 1140px) {
   .section-about { padding-top: 40px; }
}

@media all and (max-width: 1000px) {
   #main-video { min-height: 580px; }
}

@media all and (max-width: 650px) {
   .content-wrap h1 { font-size: calc((100vw - 350px)/(650 - 350) * (80 - 55) + 55px); margin-bottom: 60px; margin-top: 50px; }
   .content-wrap h1 strong { font-size: calc((100vw - 350px)/(650 - 350) * (110 - 78) + 78px);  }
}

@media all and (max-width: 495px) {
   .content-wrap h1 strong { margin-top: 15px; display: inline-block; }
   .i-button-group { flex-direction: column; align-items: flex-start; }
   .btn-wrap { margin-right: 0; margin-bottom: 10px; }
}

@media all and (max-width: 350px) {
   .content-wrap h1 { font-size: calc((100vw - 280px)/(350 - 280) * (58 - 48) + 48px); }
   .content-wrap h1 strong { font-size: calc((100vw - 280px)/(350 - 280) * (78 - 58) + 58px);  }
}

</style>