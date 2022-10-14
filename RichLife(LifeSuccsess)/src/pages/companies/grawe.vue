<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter">
      <template slot="header">
         <minimal-header @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @onClick="onShowJoinModal" @showGetInTouch="getInTouch = true"></minimal-header>
      </template>

      

      <section class="section-main i-new-section">
         <breadcrumbs class="light">
            <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
            <span>Grawe</span>
         </breadcrumbs>

         <i-container :display="'flex'" :justify="'flex-start'">
            <div class="section-main-content">
               <h1 class="main-title">GRAWE</h1>
               <p class="main-subtitle">Надежность и стабильность, проверенные веками</p>
               <i-button class="tt-u i-button-link" @onClick="getInTouch = true">Оставить заявку</i-button>
            </div>
         </i-container>
      </section>

      <companies-services-menu :registered="innerRegistered" @callUs="onCallUs" @onClick="onShowJoinModal" @openWelcome="onShowWelcome"></companies-services-menu>

      <section class="section-features">
         <i-container>
            <div class="grid-row features-row">
               <div class="features-item">
                  <div class="features-amount">1828</div>
                  <p class="features-text">год основания</p>
               </div>
            
               <div class="features-item">
                  <div class="features-amount">847.5+</div>
                  <p class="features-text">полученные премии 2017, млн. Евро</p>
               </div>

               <div class="features-item">
                  <div class="features-amount">611.6+</div>
                  <p class="features-text">Страховые выплаты 2017, млн. Евро</p>
               </div>

               <div class="features-item">
                  <div class="features-amount">1239.9</div>
                  <p class="features-text">Страховые выплаты 2017, млн. Евро</p>
               </div>
            </div>
         </i-container>
      </section>

      <section class="section-about">
         <i-container>
            <div class="row about-row">
               <div class="col about-col">
                  <div class="about-item ">
                     <h2 class="about-title"><strong>GRAWE</strong> - это</h2>
                     <div class="text-wrap">
                        <p class="about-text descr-text">За свою долгую историю, несмотря на политические и экономические кризисы, которые постигли Австрию в XIX-XX веках, группа GRAWE ни разу не прекращала своей работы. GRAWE не только выстояла в тяжелые времена, но и достигла высокого уровня развития благодаря наследованию принципов управления, направленности своей деятельности на интересы клиентов, тщательному подбору и обучению персонала.</p>
                        <p class="about-text descr-text">Многое изменилось после создания Grazer Wechselseitige Versicherung. Когда общество страхования от пожаров местного значения, сегодня - международный финансовый концерн, объединяющий в себе страховые компании, банки и компании по управлению недвижимостью. Ниже приведена структура концерна Grawe.</p>
                     </div>
                  </div>
               </div>
            
               <div class="col about-col">
                  <div class="about-item">
                     <div class="about-block"> 
                        <p class="about-text">Наш основатель планировал создание страховой компании не один год. В нелегкие времена войн и нестабильности страхование было особенно необходимо как защита, дает уверенность и спокойствие. </p>
                     </div>
                     <div class="about-block">
                        <p class="about-text">Шли годы, менялись эпохи, испытывая человечество мировым кризисом, Первой и Второй мировыми войнами; были взлеты и падения как политические, так и экономические. И GRAWE научилась двигаться в ногу со временем, всегда оставаясь гарантом стабильности для своих клиентов.</p>
                     </div>
                     <div class="about-block">
                        <p class="about-text">Ежедневно во всех дочерних компаниях GRAWE мы продолжаем объединять усилия, чтобы несмотря на то, где Вы находитесь - в Австрии, Украины, Словении или иной стране. Вы всегда чувствовали нашу поддержку.</p>
                     </div>
                  </div>
               </div>
            </div>
         </i-container>
      </section>

      <section class="section-values">
         <i-container>
            <div class="i-title dancing">Our Philosophy</div>
            <h2 class="i-title section-title values-title">Наша философия</h2>

            <div class="row values-row">
               <div class="col-6 values-col">
                  <div class="values-item">
                     <div class="watermark">01</div>
                     <h3 class="title">Страхование</h3>
                     <p class="text">социально-направленный бизнес, в основе которого гуманистические идеалы</p>
                  </div>
               </div>
               <div class="col-6 values-col">
                  <div class="values-item">
                     <div class="watermark">02</div>
                     <h3 class="title">Прибыль</h3>
                     <p class="text">это инструмент для обеспечения долгосрочного сотрудничества на рынке на благо наших клиентов и развития компании</p>
                  </div>
               </div>
               <div class="col-6 values-col">
                  <div class="values-item">
                     <div class="watermark">03</div>
                     <h3 class="title">Честный и прозрачный бизнес</h3>
                     <p class="text">честный и прозрачный бизнес как для клиентов, так и для власти</p>
                  </div>
               </div>
               <div class="col-6 values-col">
                  <div class="values-item">
                     <div class="watermark">04</div>
                     <h3 class="title">Продолжение традици</h3>
                     <p class="text">продолжение традиций австрийского концерна GRAWE: надежность, стабильность развития, использования наработанного международного опыта</p>
                  </div>
               </div>
            </div>

            <p class="values-text section-text">За свою историю компания GRAWE неоднократно была вынуждена демонстрировать высокий уровень антикризисного менеджмента. Необходимость часто искать новые решения для принципиально новых задач закалила компанию и подготовила ее к жесткой конкуренции в бизнесе XXI века. Мы научились стоять в некотором смысле вдоль течения времени, потому что осознали, что стабильность несовместима с чрезмерными амбициями. Один из самых важных постулатов GRAWE - это необходимость заработать возможно и меньше, но стабильный доход во всех компаниях концерна. Потому что только прибыльные предприятия, выполняя свою основную экономическую функцию, способны к долгосрочному выживанию в условиях свободной рыночной экономики.</p>
            <p class="values-text section-text">Сегодня мы особенно сильны в Восточной и Юго-Восточной Европе. Залогом этого всегда был и остается персонал Компании: качество отбора и подготовки специалистов, программы страхования, мотивационные пакеты, и гибкость в подходах к управлению персоналом, позволили сформировать команду, лояльную к компании, а соответственно - к нашим клиентам. Высший менеджмент концерна всех поколений неуклонно придерживается политики мотивации, но не запугивание или давления на сотрудников. Основываясь на долгосрочных перспективах, отсутствие чувства страха перед неизвестностью своего профессионального будущего и присутствие ощущение стабильности, защищенности и справедливости по отношению к себе, заставляют нас, сотрудников GRAWE, в высшей степени идентифицировать себя с целями концерна. И это не может не оказывать положительного влияния на обслуживание наших клиентов.</p>
            <i-button class="tt-u i-button-link" :margin="'40px auto 0 auto'" @onClick="getInTouch = true">Оставить заявку</i-button>
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

      <i-modal :contentMaxWidth="'600px'" :show="showWelcome" @close="showWelcome = false">
         <welcome-form @closeForm="showWelcome = false" @onRegistered="onReg"></welcome-form>
      </i-modal>

      <modal-chat :innerOpen="openChat" @closeChat="onCloseChat"></modal-chat>
   </layout>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

@Component
export default class PageGraweComponents extends Vue {

   showJoinModal: boolean = false  // флаг на открытие формы join
   showAboutModal: boolean = false  // флаг на открытие модкльного окна "о нас"
   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false
   showWelcome: boolean = false  // флаг на открытие окна с формой welcome
   innerRegistered: boolean = false // флаг при успешной отправки формы welcome (для открытия доступа ссылок из services-menu)


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
   background: url('/assets/img/companies/grawe.webp') no-repeat bottom;
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
   grid-template-columns: 1fr 1fr 1fr 1fr;
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
   line-height: 160%;
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