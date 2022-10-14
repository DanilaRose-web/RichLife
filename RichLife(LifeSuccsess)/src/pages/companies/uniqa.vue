<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch">
      <template slot="header">
         <minimal-header-uniqa @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @onClick="onShowJoinModal" @showGetInTouch="onGetInTouch" />
      </template>

      

      <section class="section-main i-new-section">
         <breadcrumbs class="light">
            <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
            <span>Uniqa</span>
         </breadcrumbs>

         <i-container :display="'flex'" :justify="'flex-start'">
            <div class="section-main-content">
               <h1 class="main-title">UNIQA</h1>
               <p class="main-subtitle">Признана лучшей страховой компанией Украины в рейтинге «ТОП-100»</p>
               <i-button class="tt-u i-button-link" @onClick="onGetInTouch">Оставить заявку</i-button>
            </div>
         </i-container>
      </section>

      <companies-services-menu :registered="innerRegistered" @callUs="onCallUs" @openNote="openNoteModal"></companies-services-menu>

      <section class="section-features">
         <i-container>
            <div class="grid-row features-row">
               <div class="features-item">
                  <div class="features-amount">1811</div>
                  <p class="features-text">год основания</p>
               </div>

               <div class="features-item">
                  <div class="features-amount">18</div>
                  <p class="features-text">стран Восточной и Центральной Европы</p>
               </div>
            
               <div class="features-item">
                  <div class="features-amount">15.5+ млн</div>
                  <p class="features-text">клиентов, которым мы предоставляем продукты и услуги, финансовую уверенность и бренд, которому доверяют.</p>
               </div>

               <div class="features-item">
                  <div class="features-amount">21 300</div>
                  <p class="features-text">сотрудников и эксклюзивных партнеров</p>
               </div>
            </div>
         </i-container>
      </section>

      <section class="section-about">
         <i-container>
            <div class="row about-row">
               <div class="col about-col">
                  <div class="about-item ">
                     <h2 class="about-title"><strong>UNIQA</strong> - это</h2>
                     <div class="text-wrap">
                        <p class="about-text descr-text">UNIQA Insurance Group является одной из ведущих страховых групп на своих основных рынках в Австрии и Центральной и Восточной Европе. Была основана в 1811 году, и в 1999 вышли на мировую арену под сокращенным названием "UNIQA". 21 300 сотрудников и эксклюзивных партнеров обслуживают более 15,5 млн. клиентов в 18 странах Европы.</p>
                        <p class="about-text descr-text">В Украине UNIQA Insurance Group представлена ​​небанковской финансовой группой УНИКА Украина, в которую входят страховые компании «УНИКА» (non-life) и «УНИКА Жизнь» (life). Более 1 тыс. сотрудников УНИКА в Украине обслуживают около 1 млн. страховых полисов.</p>
                        <p class="about-text descr-text">Страховая компания «УНИКА» работает на украинском рынке non-life страхования 27 лет. В течение многих лет Страховая компания «УНИКА» занимает ведущие позиции на рынке Украины по сборам страховых премий, выплат, активам и доле рынка non-life страхования.</p>
                     </div>
                  </div>
               </div>
            
               <div class="col about-col">
                  <div class="about-item">
                     <div class="about-block">
                        <p class="about-text">стабильно входит в ТОП-3 в сегментах страхования КАСКО, медицинского страхования и страхования имущества.</p>
                     </div>
                     <div class="about-block">
                        <p class="about-text">Ежемесячно Страховая компания «УНИКА» осуществляет страховые выплаты в сумме около 100 млн грн.</p>
                     </div>
                     <div class="about-block">
                        <p class="about-text">Поддержка клиентов 24/7 службой ассистанса, в мессенджерах Viber и Telegram, с помощью чат-ботов и мобильного приложения myUNIQA.</p>
                     </div>
                     <div class="about-block">
                        <p class="about-text">УНИКА - признана лучшей страховой компанией Украины в рейтинге «ТОП-100. Рейтинги крупнейших».</p>
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
                     <h3 class="title">Поощрение сотрудников</h3>
                     <p class="text">Поощрение сотрудников, которые берут на себя ответственность, системно мыслящих командных игроков, стремящихся обеспечить индивидуальный сервис для наших клиентов.</p>
                  </div>
               </div>
               <div class="col-6 values-col">
                  <div class="values-item">
                     <div class="watermark">02</div>
                     <h3 class="title">Наши ожидания от руководителей УНИКА</h3>
                     <p class="text">Мы постоянно соверэто лидеры, которые являются наставниками для своих коллег, которые обеспечивают искреннюю обратную связь, показывают перспективы на будущее, обеспечивая справедливость и прозрачность при принятии решений.</p>
                  </div>
               </div>
               <div class="col-6 values-col">
                  <div class="values-item">
                     <div class="watermark">03</div>
                     <h3 class="title">Стремление к развитию, эффективности и гибкости</h3>
                     <p class="text">Мы инвестируем в профессиональное развитие нашей команды, развиваем их таланты и предлагаем различные возможности для максимального использования потенциала и способностей каждого.</p>
                  </div>
               </div>
            </div>

            <p class="values-text section-text">Страховая компания «УНИКА» - обладатель международного сертификата и золотой медали Customer's Friend Superior Excellence, Международной ассоциации сертификации ICERTIAS (Цюрих, Швейцария) по образцу отношения с клиентам</p>
            <i-button class="tt-u i-button-link" :margin="'40px auto 0 auto'" @onClick="onGetInTouch">Оставить заявку</i-button>
         </i-container>
      </section>


      <i-modal :show="showJoinModal" @close="onHideJoinModal" >
         <div class="review-video">
            <join-form></join-form>
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
import { Component } from "vue-property-decorator"

import cookie from "js-cookie"

@Component
export default class PageUniqaComponents extends Vue {

   showJoinModal: boolean = false  // флаг на открытие формы join
   showAboutModal: boolean = false  // флаг на открытие модкльного окна "о нас"
   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false
   showWelcome: boolean = false  // флаг на открытие окна с формой welcome
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
      this.showWelcome = false
   }

   /**
    * Открываем форму welcome при клике на ссылки из services-menu
    */
   onShowWelcome() {
      this.showWelcome = true
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

/* section main */
.section-main {
   padding: 20px 0 120px 0;
   background: url('/assets/img/companies/uniqa.webp') no-repeat bottom;
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
   background: rgba(0, 0, 0, 0.4);
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
   grid-template-columns: repeat(4, 1fr);
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
   text-align: center;
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

.values-row {
   justify-content: center;
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
   text-align: center;
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
}

@media all and (max-width: 675px) {
   .values-col { flex: 0 0 100%; max-width: 100%; }
}

@media all and (max-width: 500px) {
   .features-row { grid-template-columns: 1fr; }
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