<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch">
      <template slot="header">
         <minimal-header-metlife @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />
      </template>

      

      <section class="section-main i-new-section">
         <breadcrumbs class="light">
            <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
            <span>MetLife</span>
         </breadcrumbs>

         <i-container :display="'flex'" :justify="'flex-start'">
            <div class="section-main-content">
               <h1 class="main-title">MetLife</h1>
               <p class="main-subtitle"><strong>№1</strong> в мире по корпоративному страхованию</p>
               <i-button class="tt-u i-button-link" @onClick="onGetInTouch">Оставить заявку</i-button>
            </div>
         </i-container>
      </section>
      
      <companies-services-menu :registered="innerRegistered" @callUs="onCallUs" @openNote="openNoteModal"></companies-services-menu>

      <section class="section-features">
         <i-container>
            <div class="grid-row features-row">
               <div class="features-item">
                  <div class="features-amount">153+</div>
                  <p class="features-text">лет финансовой надежности и стабильности</p>
               </div>
         
         
               <div class="features-item">
                  <div class="features-amount">40+</div>
                  <p class="features-text">стран, в половине из которых занимаем первые места в рейтингах страховщиков.</p>
               </div>
            
            
               <div class="features-item">
                  <div class="features-amount">100+ млн</div>
                  <p class="features-text">клиентов, которым мы предоставляем продукты и услуги, финансовую уверенность и бренд, которому доверяют.</p>
               </div>
            </div>
         </i-container>
      </section>

      <section class="section-about">
         <i-container>
            <div class="row about-row">
               <div class="col about-col">
                  <div class="about-item ">
                     <h2 class="about-title"><strong>MetLife</strong> - это</h2>
                     <div class="text-wrap">
                        <p class="about-text descr-text">153-летняя история финансовой надежности и стабильности, за время которой мы помогали людям получить больше тех возможностей, которые предоставляет жизнь.</p>
                        <p class="about-text descr-text">Это крупнейшая компания по страхованию жизни в США, занимает ведущие позиции на более чем 20 рынках страхования в Европе, Азии, Латинской Америке и Ближнем Востоке. По мере того, как мы расширяем свое присутствие на глобальном рынке, наш фокус остается неизменным - это почти 100 000 000 клиентов, которым мы предоставляем продукты и услуги, финансовую уверенность и бренд, которому доверяют.</p>
                     </div>
                  </div>
               </div>
            
               <div class="col about-col">
                  <div class="about-item">
                     <div class="about-block">
                        <p class="about-text">MetLife - это признанный лидер в корпоративном страховании, который сочетает в себе знания локального рынка с глобальными возможностями.</p>
                     </div>
                     <div class="about-block">
                        <p class="about-text">MetLife является соучредителем международного страхового пула MAXIS Global Benefits Network (Максис Глобал Бенефитс Нетворк) 1 - ведущего пула в корпоративном страховании, работающий более чем в 100 странах.</p>
                     </div>
                     <div class="about-block">
                        <p class="about-text">MetLife предлагает компаниям и индивидуальным клиентам широкий выбор страховых продуктов, включающих в себя страхование жизни и здоровья, накопительные и пенсионные планы.</p>
                     </div>
                  </div>
               </div>
            </div>
         </i-container>
      </section>

      <section class="section-values">
         <i-container>
            <div class="i-title dancing">Our Values</div>
            <h2 class="i-title section-title values-title">Наши ценности</h2>

            <div class="row values-row">
               <div class="col-6 values-col">
                  <div class="values-item">
                     <div class="watermark">01</div>
                     <h3 class="title">Клиент прежде всего</h3>
                     <p class="text">Забота и уважительное отношение к клиентам - основа нашей деятельности. Именно клиентоориентированность определяет нашу работу и формирует корпоративную культуру. </p>
                  </div>
               </div>
               <div class="col-6 values-col">
                  <div class="values-item">
                     <div class="watermark">02</div>
                     <h3 class="title">Быть лучше</h3>
                     <p class="text">Мы постоянно совершенствуемся и стремимся к предоставлению страховых услуг высокого качества. Будучи лидером в области страхования жизни мы продолжаем работу над нашими продуктами. </p>
                  </div>
               </div>
               <div class="col-6 values-col">
                  <div class="values-item">
                     <div class="watermark">03</div>
                     <h3 class="title">Упрощать процессы</h3>
                     <p class="text">Продукты, которые предлагает наша отрасль, не всегда просты для понимания, поэтому мы стараемся находить простые способы рассказать клиентам о наших продуктах. </p>
                  </div>
               </div>
               <div class="col-6 values-col">
                  <div class="values-item">
                     <div class="watermark">04</div>
                     <h3 class="title">Идти к успеху вместе</h3>
                     <p class="text">Объединенные общей целью, мы неуклонно придерживаемся принципов честности и добросовестности, открытости и привлечения. Мы с гордостью принимаем и применяем на практике лучшие идеи от подразделений нашей компании.</p>
                  </div>
               </div>
            </div>

            <p class="values-text section-text">MetLife работает на рынках более чем 40 стран, в половине из которых занимает первые места в рейтингах страховщиков. Рейтинг финансовой надежности для Metropolitan Life Insurance Company 2 : <strong>Moody's Investors Service: Aa3, Standard & Poor's Ratings Services: AA-, AM Best Company, Inc .: A, Fitch Ratings: AA-</strong></p>
            <p class="values-text section-text green"><strong>Мы признанны экспертом и одной из наиболее уважаемых компаний на рынке страхования жизни в Украине и мире.</strong></p>
            <i-button class="tt-u i-button-link" :margin="'40px auto 0 auto'" @onClick="onGetInTouch">Оставить заявку</i-button>
         </i-container>
      </section>

      <section class="section-licenses">
         <i-container>
            <div class="i-title dancing">Our Licenses</div>
            <h2 class="i-title section-title values-title">Лицензии</h2>
            
            <companies-docs></companies-docs>
         </i-container>
      </section>


      <i-modal :contentMaxWidth="'600px'" :show="showJoinModal" @close="onHideJoinModal" >
         <join-form></join-form>
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
import { Component } from "vue-property-decorator"

import cookie from "js-cookie"

@Component
export default class PageMetLifeComponents extends Vue {

   showJoinModal: boolean = false  // флаг на открытие формы join
   showAboutModal: boolean = false  // флаг на открытие модкльного окна "о нас"
   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false
   innerRegistered: boolean = false // флаг при успешной отправки формы welcome (для открытия доступа ссылок из services-menu)
   noteGetInTouch: boolean = false // фдаг на открытие окна с проверкой на авторизацию


   mounted() {
      this.lasyMoveOnLinks()
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
    * Переопределяем флаг, когда была отправлена форма welcome
    */
   onReg(registered: boolean) {
      this.innerRegistered = registered
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

/* section main */
.section-main {
   padding: 20px 0 120px 0;
   background: url('/assets/img/companies/metlife-lg.webp') no-repeat bottom;
   /* background-size: cover; */
   background-attachment: fixed;
   position: relative;
}

.section-main::before {
   content: '';
   position: absolute;
   top: 0;
   left: 0;
   width: 100%;
   height: 100%;
   background: rgba(0, 0, 0, 0.2);
}

.section-main-content {
   margin-top: 100px;
   display: flex;
   flex-direction: column;
   align-items: flex-start;
}

.main-title {
   margin-bottom: 10px;
   font-size: 100px;
   font-weight: 700;
   color: #fff;
}

.main-subtitle {
   margin-bottom: 40px;
   font-size: 25px;
   font-weight: 600;
   line-height: 130%;
   color: #fff;
   max-width: 650px;
}

.main-subtitle strong {
   font-size: 35px;
   font-weight: 700;
   color: #12be83;
}





/* section features */
.section-features {
   padding: 60px 0;
   position: relative;
}

.features-row {
   display: grid;
   grid-template-columns: 1fr 1fr 1fr;
   grid-template-rows: auto;
   gap: 30px;
}

.features-item {
   display: flex;
   flex-direction: column;
   align-items: center;
}

.features-amount {
   margin-bottom: 10px;
   font-size: 40px;
   font-weight: 700;
   color: #12be83;
}

.features-text {
   font-size: 15px;
   font-weight: 500;
   line-height: 140%;
   color: #121B23;
   text-align: center;
   max-width: 350px;
}






/* section about */
.section-about {
   padding: 60px 0 80px 0;
}

.about-row {
   display: flex;
   align-items: flex-end;
   justify-content: space-between;
}

.about-col:first-child {
   margin-right: 40px;
}

.about-title {
   margin-bottom: 30px;
   font-size: 30px;
   font-weight: 700;
   color: #121B23;
}

.about-title strong {
   font-size: 45px;
   color: #12be83;
}

.about-text {
   font-size: 15px;
   font-weight: 500;
   line-height: 150%;
   color: #121B23;
}

.text-wrap {
   padding: 30px;
   background: rgba(18, 190, 131, 0.03);
   border-radius: 15px;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.about-text.descr-text {
   font-family: 'Futura New Book';
   font-size: 20px;
   line-height: 140%;
   max-width: 500px;
}

.about-text.descr-text:not(:first-child) {
   margin-top: 15px;
}

.about-block {
   padding: 15px;
   position: relative;
   border-radius: 15px;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
   background: #F8F9FC;
}

.about-block::before {
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

.about-block:not(:last-child) {
   margin-bottom: 50px;
}






/* section values */
.section-values {
   padding: 60px 0 80px 0;
}

.values-col {
   margin-bottom: 30px;
   display: flex;
}

.values-item {
   padding: 20px;
   position: relative;
   display: flex;
   flex-direction: column;
   align-items: center;
   width: 100%;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
   border-radius: 15px;
}

.watermark {
   position: absolute;
   left: 5px;
   top: 5px;
   font-size: 110px;
   font-weight: 700;
   color: rgba(18, 190, 131, 0.1);
   
}

.values-item .title {
   margin-bottom: 10px;
   font-size: 20px;
   font-weight: 700;
   line-height: 130%;
   color: #12be83;
   text-align: center;
}

.values-item .text {
   font-size: 20px;
   font-weight: 500;
   line-height: 120%;
   color: #121B23;
   text-align: center;
   font-family: 'Futura New Book', sans-serif;
}


.section-text {
   margin: 30px auto 15px auto;
   font-size: 16px;
   font-weight: 500;
   line-height: 140%;
   color: #121B23;
   max-width: 800px;
}

.section-text strong {
   font-weight: 700;
}

.section-text.green {
   color: #12be83;
}




/* section licenses */
.section-licenses {
   padding-bottom: 80px;
}


@media all and (max-width: 970px) {
   .about-col { flex: 0 0 100%; max-width: 100%; }
   .about-col:first-child { margin-right: 0; margin-bottom: 60px; }
   .about-text.descr-text { max-width: 100%; }
}

@media all and (max-width: 800px) {
   .features-row { grid-template-columns: 1fr 1fr; }
   .features-item:last-child { grid-column: 1/3; }
}

@media all and (max-width: 675px) {
   .values-col { flex: 0 0 100%; max-width: 100%; }
}

@media all and (max-width: 500px) {
   .features-row { grid-template-columns: 1fr; }
   .features-item:last-child { grid-column: 1/2; }
   .text-wrap { padding: 20px; }
   .main-title { font-size: calc((100vw - 280px)/(500 - 280) * (100 - 60) + 60px); }
}

@media all and (max-width: 370px) {
   .about-text.descr-text { font-size: 19px; }
}


/* media для тач-скринов */
@media (pointer: coarse) {
   .section-main { background-attachment: inherit; background-size: cover; background-position: center; }
}
</style>