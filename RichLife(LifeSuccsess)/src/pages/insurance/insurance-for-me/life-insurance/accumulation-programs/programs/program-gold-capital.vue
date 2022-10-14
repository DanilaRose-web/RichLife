<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch">
      <template slot="header">
         <minimal-header-metlife @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />

         <!-- <services-static-menu>
            <ul class="static-menu">
               <li><router-link to="pension-provision">Дополнительное пенсионное обеспечение</router-link></li>
               <li class="active"><router-link to="accumulation-programs">Комплексные программы накопления</router-link></li>
            </ul>
         </services-static-menu> -->
      </template>

      <breadcrumbs>
         <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <router-link to="metlife">MetLife <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <!-- <router-link to="insurance-for-me">Страхование для меня <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link> -->
         <router-link to="life-insurance">Страхование жизни <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <router-link to="accumulation-programs">Комплексные программы накопления <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <span>Пакет "Золотой Капитал" для мужчин и женщин</span>
      </breadcrumbs>

      <section class="section-main i-section">
         <i-container>
            <span class="i-title dancing">Gold Capital</span>
            <h1 class="i-title section-title">Пакет "Золотой Капитал" для мужчин и женщин</h1>
            <h2 class="i-subtitle">Компания «МетЛайф» предлагает решение для накоплений на свой заслуженный отдых в будущем и финансовую независимость.</h2>

            <div class="table-wrap">
               <h3 class="table-title center xl">Состав пакета</h3>

               <div class="table-content">
                  <h4 class="table-title center lg">Договор долгосрочного страхования жизни</h4>
                  <div class="table-block">
                     <div class="table-block-item">
                        <h5 class="table-title center md">Программа страхования основных рисков</h5>
                        <div class="table-row">
                           <h6 class="table-flex-title center sm">E</h6>
                           <p>Страхование на случай смерти или дожизни</p>
                        </div>
                     </div>

                     <div class="table-block-item">
                        <h5 class="table-title center md">Программы страхования дополнительных рисков</h5>
                        <div class="table-row">
                           <h6 class="table-flex-title center sm">2ADob</h6>
                           <p>Страхование на случай смерти в результате несчастного случая с выплатой дополнительной страховой суммы в случае сиротства</p>
                        </div>
                        <div class="table-row">
                           <h6 class="table-flex-title">W</h6>
                           <p>Страхование на случай постоянной и полной нетрудоспособности Страхователя (освобождение Страхователя от уплаты страховых премий на период нетрудоспособности)</p>
                        </div>
                     </div>
                  </div>
               </div>

               <div class="table-content">
                  <h4 class="table-title center lg">Договор страхования жизни</h4>
                  <div class="table-block">
                     <div class="table-block-item">
                        <h5 class="table-title center md">Программа страхования основных рисков</h5>
                        <div class="table-row">
                           <h6 class="table-flex-title center sm">TERM</h6>
                           <p>Страхование на случай смерти на определенный срок или до определенного возраста (со страховой суммой 50 грн.)</p>
                        </div>
                     </div>

                     <div class="table-block-item">
                        <h5 class="table-title center md">Программы страхования дополнительных рисков</h5>
                        <div class="table-row">
                           <h6 class="table-flex-title center sm">2PI</h6>
                           <p>Страхование на случай постоянной нетрудоспособности в результате несчастного случая</p>
                        </div>
                        <div class="table-row">
                           <h6 class="table-flex-title center sm">CI7</h6>
                           <p>Страхование на случай одного из 7-ми критических заболеваний – для мужчин</p>
                        </div>
                        <div class="table-row">
                           <h6 class="table-flex-title center sm">CFB</h6>
                           <p>Страхование на случай критических женских рисков – для женщин</p>
                        </div>
                        <div class="table-row">
                           <h6 class="table-flex-title center sm">BI</h6>
                           <p>Страхование на случай телесных повреждений в результате несчастного случая</p>
                        </div>
                        <div class="table-row">
                           <h6 class="table-flex-title center sm">Sa</h6>
                           <p>Страхование на случай хирургического вмешательства в результате несчастного случая</p>
                        </div>
                        <div class="table-row">
                           <h6 class="table-flex-title center sm">BBB (Акция)</h6>
                           <p>Страхование на случай переломов и/или ожогов (предоставляется автоматически с фиксированной страховой суммой 30 000 грн. и страховой премией в первый год действия договора страхования 1 грн.)</p>
                        </div>
                     </div>
                  </div>
               </div>
            </div>

            <div class="descr-wrap">
               <div class="descr-block">
                  <h4>Вводный возраст</h4>
                  <p>18-65 лет</p>
               </div>
               <div class="descr-block">
                  <h4>Срок страхования</h4>
                  <p>Срок: 10, 15, 16, 17, 18, 19, 20, 25 лет</p>
                  <p>До достижения возраста: 50, 55, 60, 65, 75 лет</p>
               </div>
               <div class="descr-block">
                  <h4>Минимальная страховая премия</h4>
                  <p>4000 грн.</p>
               </div>
               <div class="descr-block">
                  <h4>Максимальная страховая премия</h4>
                  <p>Не ограничена</p>
               </div>
               <div class="descr-block">
                  <h4>Страховая сумма для мужчин</h4>
                  <p>E – не ограничен (зависит от пола, возраста, служебных обязанностей застрахованного лица, срока страхования и размера страховой премии)</p>
                  <p>TERM – 50 грн</p>
                  <p>ADob = страховая сумма по E*2</p>
                  <p>ADob (в случае сиротства) – максимум 500 000 грн</p>
                  <p>PI = страховая сумма по E*2</p>
                  <p>CI7 – 50000 грн</p>
                  <p>BI – 15 000 грн</p>
                  <p>Sa – 15 000 грн</p>
                  <p>BBB (акция) – 30 000 грн</p>
               </div>
               <div class="descr-block">
                  <h4>Страховая сумма для женщин</h4>
                  <p>E – не ограничен (зависит от пола, возраста, служебных обязанностей застрахованного лица, срока страхования и размера страховой премии)</p>
                  <p>TERM – 50 грн</p>
                  <p>ADob = страховая сумма по E*2</p>
                  <p>ADob (в случае сиротства) – максимум 500 000 грн</p>
                  <p>PI = страховая сумма по E*2</p>
                  <p>CFB – 100000 грн./500 грн./5 000 грн./500 000 грн./5 000 грн./500 грн</p>
                  <p>BI – 15 000 грн</p>
                  <p>Sa – 15 000 грн</p>
                  <p>BBB (акция) – 30 000 грн</p>
               </div>
               <div class="descr-block">
                  <h4>Право на негарантированный Бонус (Дополнительный Инвестиционный Доход)</h4>
                  <p>Предоставляется для договора долгосрочного страхования жизни</p>
               </div>
               <div class="descr-block">
                  <h4>Положение об индексации</h4>
                  <p>Применяется (кроме ВОВ (акция), CI7 – для мужчин, CFB – для женщин)</p>
               </div>
               <div class="descr-block">
                  <h4>Конвертация договора страхования в полностью уплаченный</h4>
                  <p>Автоматически осуществляется по договору долгосрочного страхования жизни после формирования выкупной суммы</p>
               </div>
               <div class="descr-block">
                  <h4>Автоматический кредит</h4>
                  <p>По заявлению Страхователя по договору долгосрочного страхования жизни после формирования выкупной суммы</p>
               </div>
               <div class="descr-block">
                  <h4>Налоговая скидка</h4>
                  <p>Может быть получена на сумму страховой премии по договору долгосрочного страхования жизни</p>
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
export default class PageProgramGoldCapitalComponents extends Vue {  // Страница - Копмплексные программы накопления

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

.table-wrap {
   margin: 0 auto;
   max-width: 1000px;
}

.table-content {
   margin-top: 20px;
}

.table-row {
   margin: 10px 0;
   padding: 10px;
   display: flex;
   align-items: center;
   width: 100%;
   flex-wrap: nowrap;
   border-radius: 15px;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.table-block {
   margin-top: 20px;
   padding: 20px;
   border-radius: 15px;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.table-block-item {
   margin-top: 30px;
}

.table-title {
   font-weight: 700;
}

.table-title.center  {
   text-align: center;
}

.table-title.xl {
   font-size: 23px;
}
.table-title.lg {
   font-size: 20px;
   color: #12be83;
}
.table-title.md {
   font-size: 17px;
}


.table-flex-title {
   margin-right: 20px;
   max-width: 100px;
   width: 100%;
   display: flex;
   align-items: center;
   justify-content: center;
   text-align: center;
   font-weight: 700;
}

.table-flex-title.sm {
   font-size: 15px;
}

.table-block p {
   font-size: 15px;
   font-weight: 500;
   line-height: 140%;
   color: #121B23;
}





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

.descr-wrap h4 {
   font-size: 18px;
   font-weight: 700;
   line-height: 120%;
   color: #121B23;
}

.descr-wrap h4.mt {
   margin-top: 40px;
}

.descr-block p {
   margin-top: 10px;
   font-size: 15px;
   font-weight: 500;
   line-height: 150%;
   color: #121B23;
}

.descr-block p.strong {
   font-size: 17px;
   font-weight: 700;
}

.descr-list {
   margin: 20px 0;
}



@media all and (max-width: 600px) {
   .table-row { flex-direction: column; align-items: center; }
   .table-flex-title { margin-right: 0; margin-bottom: 5px; }
}
</style>