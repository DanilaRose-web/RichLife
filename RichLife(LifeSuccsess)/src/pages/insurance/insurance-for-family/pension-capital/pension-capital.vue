<template>

   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch">
      <template slot="header">
         <minimal-header-metlife @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />

         <!-- <services-static-menu>
            <ul class="static-menu">
               <li><router-link to="childhood-critical-illness">Детское страхование от критических заболеваний</router-link></li>
               <li><router-link to="loss-of-breadwinner">Страхование в случае потери кормильца</router-link></li>
               <li><router-link to="capital-for-children">Накопление капитала для детей</router-link></li>
               <li class="active"><router-link to="pension-capital">Накопление на собственную пенсию</router-link></li>
            </ul>
         </services-static-menu> -->
      </template>

      <breadcrumbs>
         <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <router-link to="metlife">MetLife <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <!-- <router-link to="insurance-for-family">Страхование для моей семьи <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link> -->
         <span>Накопление на собственную пенсию</span>
      </breadcrumbs>

      <section class="section-main i-section">
         <i-container>
            <span class="i-title dancing">Pension Capital</span>
            <h1 class="i-title section-title">Дополнительное пенсионное обеспечение и накопление</h1>
            <h4 class="i-subtitle">Дополнительное пенсионное обеспечение и накопление до определенного события – ваша финансовая независимость от детей, родственников и государства после прекращения трудовой деятельности.</h4>
            
            <div class="descr-wrap">
               <h4 class="static-md-title ml">Компания «МетЛайф» предлагает следующие варианты осуществления страховой выплаты с возможностью получения выплаты по истечении срока накопления</h4>
               <div class="descr-block">
                  <h4 class="static-md-title left">Единовременная выплата</h4>
                  <p>В случае дожития Застрахованного Лица до окончания срока действия Договора страхования, ЧАО «МетЛайф» произведет страховую выплату на случай доживания, состоящей из</p>
                  <ul class="i-ul-list descr-list">
                     <li>страховая сумма по программе страхования основных рисков (программы PEAD, PE Single);</li>
                     <li>суммы Негарантированного Бонуса (Дополнительного Инвестиционного Дохода);</li>
                     <li>суммы Специального Фонда Индексации (только при применении индексации).</li>
                  </ul>
                  <p>Страховая выплата на случай дожития может быть осуществлена ​​одной денежной суммой, или Застрахованное лицо может выбрать один из способов осуществления страховой выплаты, определенных в «Положении о порядке осуществления страховых выплат».</p>
               </div>

               <h4 class="static-md-title ml">В соответствии с письменным заявлением Застрахованного Лица (далее – получатель) страховая выплата может быть осуществлена ​​следующим образом</h4>

               <div class="descr-block">
                  <h4 class="static-md-title left">1. Страховая выплата оговоренными равными частями (Ануитет на срок, уплачиваемый оговоренными равными частями)</h4>
                  <p>В случае избрания этого способа осуществления выплат получатель будет получать страховую выплату равными частями установленного им самим размера (размер Аннуитетной Выплаты). В Приложении к Договору страхования, который будет направлен для подтверждения применения этого способа, будет определен период, в течение которого ЧАО «МетЛайф» будет осуществлять такие Аннуитетные выплаты. В случае смерти получателя до окончания действия «Положения о порядке осуществления Страховых выплат» ЧАО «МетЛайф» произведет единовременную выплату, рассчитанную на дату смерти получателя, в размере всех неуплаченных будущих аннуитетных выплат с учетом инвестиционного дохода. Такая выплата будет произведена лицу, имеющему право на его получение согласно действующему законодательству.</p>
               </div>
               <div class="descr-block">
                  <h4 class="static-md-title left">2. Страховая выплата в течение установленного периода (Ануитет на срок, оплачиваемый в течение оговоренного срока)</h4>
                  <p>В случае избрания этого способа выплат выплат получатель будет получать страховую выплату равными частями в течение установленного им самим периода.  В Приложении к Договору страхования, который будет направлен для подтверждения применения этого способа, будет определен размер таких Аннуитетных выплат. В случае смерти получателя до окончания действия «Положения о порядке осуществления Страховых выплат» ЧАО «МетЛайф» произведет единовременную выплату, рассчитанную на дату смерти получателя, в размере всех неуплаченных будущих аннуитетных выплат с учетом инвестиционного дохода. Такая выплата будет произведена лицу, имеющему право на его получение согласно действующему законодательству.</p>
               </div>
               <div class="descr-block">
                  <h4 class="static-md-title left">3. Пожизненная пенсия (Пожизненный аннуитет)</h4>
                  <p>Получатель будет получать страховую выплату в форме пожизненной пенсии, то есть в форме регулярных сумм, которые будут уплачиваться ему до конца жизни. Размер пенсии будет указан в соответствующем приложении к Договору страхования. В случае смерти клиента выплата пенсии прекращается.</p>
               </div>
               <div class="descr-block">
                  <h4 class="static-md-title left">4. Пожизненная пенсия, гарантированная на определенный срок (Пожизненный аннуитет, гарантированный на определенный срок)</h4>
                  <p>Если получатель выбирает этот способ выплат, размер и период, в течение которого будут осуществляться выплаты пенсии, будут указаны в соответствующем Приложении к Договору страхования, и получатель будет получать такие выплаты до конца его жизни.</p>
                  <p>В случае смерти получателя до окончания гарантированного периода ЧАО «МетЛайф» произведет единовременную выплату, рассчитанную на дату смерти получателя, в размере всех неуплаченных до даты окончания гарантированного периода будущих Аннуитетных выплат с учетом инвестиционного дохода. Такая выплата будет произведена лицу, имеющему право на его получение согласно действующему законодательству.</p>
               </div>
               <div class="descr-block">
                  <h4 class="static-md-title left">5. Пожизненная пенсия, которая может быть передана в размере 60% (Пожизненный аннуитет, который может быть передан супругам получателя в размере 60% от суммы Пожизненного аннуитета)</h4>
                  <p>Получатель будет получать причитающуюся страховую выплату в форме пожизненной пенсии, размер которой будет указан в Приложении к Договору страхования, который будет направлен для подтверждения применения этого способа. В случае смерти получателя суммы в размере 60% от аннуитетных выплат будут уплачиваться также в форме пожизненной пенсии супругам получателя.</p>
               </div>
            </div>

            <div class="navigate-block">
               <div class="navigate-row row">
                  <div class="col-6 navigate-col">
                     <router-link to="program-e" class="navigate-link">
                        <div class="watermark">01</div>
                        <h3>Прогармма страхования Е</h3>
                        <p>Страхование на случай смерти или дожития</p>
                     </router-link>
                  </div>
                  <div class="col-6 navigate-col">
                     <router-link to="program-e-single" class="navigate-link">
                        <div class="watermark">02</div>
                        <h3>Программа страхования E Single</h3>
                        <p>Страхование на случай смерти или дожития с возможностью уплаты единовременной страховой премии</p>
                     </router-link>
                  </div>
                  <div class="col-6 navigate-col">
                     <router-link to="program-pead" class="navigate-link">
                        <div class="watermark">03</div>
                        <h3>Программа страхования PEAD</h3>
                        <p>Страхование на случай дожития до определенного возраста или на определенный срок</p>
                     </router-link>
                  </div>
                  <div class="col-6 navigate-col">
                     <router-link to="program-pe-single" class="navigate-link">
                        <div class="watermark">04</div>
                        <h3>PE Single</h3>
                        <p>Страхование на случай дожития до определенного возраста или на определенный срок с возможностью уплаты единовременной страховой премии</p>
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
export default class PagePensionCapitalComponents extends Vue {  // Страница - Страхование жизни

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

.static-md-title.left {
   margin: 0 0 20px 0;
   text-align: left;
}

.static-md-title.ml {
   margin: 70px 0 0 0;
   text-align: left;
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