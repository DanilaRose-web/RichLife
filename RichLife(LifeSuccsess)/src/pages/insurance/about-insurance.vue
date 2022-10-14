<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter">
      <template slot="header">
         <!-- <layout-header class="static" @onClick="onShowJoinModal"></layout-header> -->
         <minimal-header @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" @onClick="onShowJoinModal" @showGetInTouch="getInTouch = true"></minimal-header>
      </template>


      <!-- Что такое страхование жизни -->
      <div class="insurance">
         <div class="insurance-bg">
            <p>СТРАХОВАНИЕ</p>
         </div>
         <i-container>
            <div class="insurance-content">
               <div class="grid-item insurance-first">
                  <p class="insurance-text"><strong>Страхование жизни</strong> — страхование, предусматривающее защиту имущественных интересов застрахованного лица, связанных с его жизнью и смертью. <strong>Страхование жизни обычно связано с долговременными интересами страхователя/застрахованного лица в силу того, что жизнь рассматривается как длительное состояние, и, соответственно, событие смерти видится непрогнозируемым и отдалённым.</strong> Страхование жизни предусматривает как правило, регулярные долговременные финансовые отношения между страхователем и страховщиком.</p>
               </div>
               <div class="grid-item insurance-second">
                  <p class="insurance-text">Страхование жизни позволяет человеку решить целый комплекс социально-экономических проблем. Условно эти задачи можно объединить в две группы: социальные и финансовые. Реализация первых позволяет преодолеть недостаточность системы государственного социального страхования и обеспечения (накопление определенных денежных сумм, например, к выходу на пенсию, или к совершеннолетию, или к другим событиям в жизни застрахованного лица). Реализация вторых является защитой финансовых интересов страхователя или застрахованного лица при наступлении смерти. Итак, со страхвованием жизни в целом понятно, но кто может предоставить нам такого рода страхование??? Едем дальше</p>
               </div>
            </div>
            <div class="insurance-small-block">
               <div class="small-block-border">
                  <p class="small-block-text">Количество людей, оформивших страховой полис в США и Европе составляет около <strong>95%</strong>. В то же время на Украине этот показатель равен <strong>3%</strong></p>
               </div>
            </div>
         </i-container>
      </div>

      <!-- Страховые копании -->
      <section class="section-companies">
         <h4 class="i-title dancing">Insurance Companies</h4>
         <h3 class="insurance-title">Страховые компании</h3>

         <div class="section-companies-content">
            <i-container>
               <div class="companies-block">
                  <h5 class="insurance-title small">Какова роль страховых компаний?</h5>
                  <h6 class="insurance-subtitle">Страховая компания — исторически определённая общественная форма функционирования страхового фонда, представляет собой обособленную структуру, осуществляющую заключение договоров страхования и их обслуживание.</h6>

                  <div class="text-block">
                     <div class="text-icon"><img src="/assets/img/icons/insurance.svg" alt=""></div>
                     <p>Страховая компания - юридическое лицо (организация), целью которой, как и всех других компаний, является получение прибыли. Каждый из нас, кто покупает страховой полис (страхователь) платит в страховую компанию страховой взнос, который пополняет страховой фонд. Таким образом, мы покупаем уверенность в том, что, в случае необходимости, из него нам будет выплачено страховое возмещение в полном объеме. Клиентов много, взносов много, а вот несчастных случаев, и соответственно страховых выплат, происходит мало. </p>
                  </div>

                  <div class="text-block">
                     <div class="text-icon"><img src="/assets/img/icons/insurance.svg" alt=""></div>
                     <p>Поэтому если у кого-то из произошел страховой случай, он получает из этого фонда возмещение, иногда значительно превышающее уплаченный им страховой взнос. То есть фактически идет перераспределение средств: взносы тех, у кого ничего не произошло, уходят на выплату тем, у кого что-то произошло. Страховая компания имеет дело с оценкой вероятности наступления страхового случая и с оценкой риска.</p>
                  </div>

                  <div class="text-block">
                     <div class="text-icon"><img src="/assets/img/icons/insurance.svg" alt=""></div>
                     <p>Чем ниже вероятность наступления случая, тем дешевле страховой взнос. То есть чем больше все обращаются за страховым возмещением, тем дороже становится взнос для всех! И наоборот, чем меньше людей обращаются за страховым возмещением, тем дешевле будет страховка для всех! Размер взноса рассчитывается страховой компанией таким образом, чтобы объем всех выплат составлял не более 75-80% от всех полученных взносов. Остальные деньги уходят на расходы, которые есть в любой организации: зарплаты сотрудникам, содержание офисов, изготовление правил и бланков полисов и прочее.</p>
                  </div>

                  <div class="text-block">
                     <div class="text-icon"><img src="/assets/img/icons/insurance.svg" alt=""></div>
                     <p>Чтобы компания могла вовремя и полностью платить тем, кто заплатил взнос, но несчастный случай их не миновал, она должна быть прибыльной и эффективной! При страховании мы не теряем деньги, если с нами не происходит ничего страшного. Приобретая страховку, мы покупаем себе спокойствие. Мы не беспокоимся о том, где взять деньги на ремонт автомобиля, на лечение или восстановление квартиры, если произойдет несчастный случай. А если несчастье все-таки случится, страховое возмещение покроет расходы на ремонт или покупку нового имущества.</p>
                  </div>
               </div>
            </i-container>
         </div>
      </section>

      <section class="section-types">
         <i-container>
            <div class="types-block">
    
                  <div class="item first">
                     <h4 class="i-title dancing types-title">Types Of Insurance</h4>
                     <h3 class="i-title insurance-title types-title">Основные типы страхования жизни</h3>

                     <div class="text-content">
                        <p>Страховые программы по страхованию жизни бывают разные, но можно выделить 3 основных типа. Давайте рассмотрим их</p>
                     </div>
                  </div>
            
                  <div class="item second">
                     <div class="insurance-type">
                        <div class="type-number">01</div>
                        <div class="type-info">
                           <div class="type-title">Рисковое</div>
                           <p class="type-text">В чистом виде рисковое страхование жизни подразумевает такие страховые случаи, как <strong>уход из жизни</strong> или <strong>критические заболевания</strong>. В таком случае страхуемый делает один взнос или платит их регулярно — здесь все зависит от договора. Когда наступает страховой случай, деньги получают его родственники.</p>
                        </div>
                     </div>
                     <div class="insurance-type">
                        <div class="type-number">02</div>
                        <div class="type-info">
                           <div class="type-title">Накопительное</div>
                           <p class="type-text">Сочетание страховки и накоплений. В классическом накопительном страховании есть фиксированная доходность. Правда, и возможный доход будет ниже, чем при инвестиционном страховании. тоже самое, что и рисковое + выплату вы получаете по дожитию до определенного события</p>
                        </div>
                     </div>
                     <div class="insurance-type">
                        <div class="type-number">03</div>
                        <div class="type-info">
                           <div class="type-title">Инвестиционное</div>
                           <p class="type-text">В этом случае вы позволяете страховой компании распоряжаться вашими деньгами. Накопления делятся на две части: <br> <br>  <strong>гарантийная часть</strong> обеспечит возврат ваших денег, если ситуация на фондовом рынке будет неблагоприятной; <br> <br> <strong>инвестиционная часть</strong> может обеспечить дополнительный доход.</p>
                        </div>
                     </div>
                  </div>
            </div>
         </i-container>
      </section>

      <!-- Форма "Присоединиться" -->
      <i-modal :show="showJoinModal" @close="onHideJoinModal" >
         <join-form></join-form>
      </i-modal>

      <!-- Форма "Оставить заявку" -->
      <i-modal :contentMaxWidth="'600px'" :show="getInTouch" @close="getInTouch = false">
         <get-in-touch></get-in-touch>
      </i-modal>
   </layout>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

@Component
export default class PageInsuranceComponent extends Vue {

   showJoinModal: boolean = false  // флаг на открытие формы join
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false
   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"


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


}
</script>

<style scoped>

.insurance {
   position: relative;
}

.insurance-bg {
   position: absolute;
   top: 0;
   left: 50%;
   transform: translateX(-50%);
   width: 100%;
   height: 30%;
   overflow: hidden;
   display: flex;
   flex-direction: column;
   align-items: center;
   background: #F8F9FC;
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.1);
}

.insurance-bg p {
   font-size: 180px;
   font-weight: 700;
   text-transform: uppercase;
   color: rgba(18, 27, 35, 0.05);
   text-align: center;
}

.insurance-content {
   margin: 0 auto;
   padding-top: 60px;
   display: grid;
   grid-template-columns: 1fr 1fr;
   grid-template-rows: 1fr;
   gap: 30px;
   max-width: 1100px;
}

.grid-item {
   padding: 70px 40px;
   position: relative;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.grid-item::before {
   content: '';
   position: absolute;
   top: 0;
   left: 0;
   width: 100%;
   height: 100%;
   background: rgba(255, 255, 255, 0.85);
}

.insurance-first {
   background: url('/assets/img/insurance/insurance3.webp') no-repeat center;
   background-size: cover;
}

.insurance-second {
   background: url('/assets/img/insurance/insurance4.webp') no-repeat center;
   background-size: cover;
}


.insurance-text {
   position: relative;
   z-index: 1;
   font-size: 17px;
   font-weight: 500;
   line-height: 160%;
   color: #121B23;
}

.insurance-text strong {
   font-weight: 700;
}


.insurance-small-block {
   margin: -40px auto 0 auto;
   padding: 15px;
   background: #121B23;
   width: max-content;
   position: relative;
   z-index: 2;
   max-width: 600px;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.small-block-border {
   padding: 20px;
   border: 1px solid #fff;
}

.small-block-text {
   font-size: 18px;
   font-weight: 600;
   line-height: 150%;
   color: #fff;
   text-align: center;
}

.small-block-text strong {
   font-weight: 700;
   color: #12be83;
}












/* Страховые компании */
.insurance-title {
   margin: 0 auto 40px auto;
   font-size: 40px;
   font-weight: 700;
   line-height: 120%;
   color: #121B23;
   text-align: center;
}

.section-companies {
   padding: 100px 0;
}

.section-companies-content {
   padding: 80px 0;
   position: relative;
   background: url('/assets/img/insurance/companies-bg.webp') no-repeat center;
   background-size: cover;
}

/* Dancing */
.i-title.dancing {
   margin-bottom: 15px;
   font-family: 'Dancing Script', cursive;
   font-family: 'Astrum', cursive;
   font-size: 50px;
   font-weight: 600;
   color: #12be83;
   text-align: center;
   position: relative;
   z-index: 1;
   text-transform: none;
}

.companies-block {
   margin: 0 auto;
   padding: 70px;
   background: #fff;
   /* border: 1px solid #121B23; */
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.1);
   max-width: 900px;
}

.insurance-title.small {
   margin: 0 auto 20px auto;
   font-family: 'Astrum', cursive;
   font-size: 35px;
   font-weight: 600;
   line-height: 100%;
   color: #121B23;
   text-align: center;
}

.insurance-subtitle {
   margin: 0 auto 40px auto;
   font-size: 18px;
   font-weight: 500;
   line-height: 140%;
   color: #121B23;
   max-width: 500px;
   text-align: center;
}

.text-block {
   display: flex;
   flex-direction: column;
   align-items: center;
}

.text-block:not(:last-child) {
   margin-bottom: 30px;
}

.text-icon {
   margin-bottom: 20px;
   width: 60px;
   height: 60px;
   border-radius: 50%;
   /* background: #12be83; */
   display: flex;
   align-items: center;
   justify-content: center;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.text-icon img {
   max-width: 60px;
   height: auto;
}

.text-block p {
   font-size: 15px;
   font-weight: 500;
   line-height: 160%;
   color: #121B23;
   /* text-align: center; */
}







/* Типы страховых программ */
.section-types {
   padding-bottom: 150px;
}

.types-block {
   margin: 0 auto;
   display: flex;
   align-items: flex-start;
   justify-content: space-between;
   width: 100%;
}


.types-block .item {
   width: 100%;
}

.types-block .item.first {
   margin-right: 50px;
}


.i-title.types-title {
   text-align: left;
   text-transform: none;
}

.text-content {
   padding: 50px;
   background: #e6e6eb;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
   max-width: 500px;
}

.text-content p {
   /* font-family: 'Astrum', cursive; */
   font-size: 18px;
   font-weight: 600;
   line-height: 160%;
   color: #121B23;
}


/* описание типов страхования */
.insurance-type {
   padding: 20px;
   position: relative;
   display: flex;
   align-items: flex-start;
   background: #e6e6eb;
   width: 100%;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.insurance-type::before {
   content: '';
   position: absolute;
   top: -20px;
   left: -20px;
   width: 58px;
   height: 58px;
   background: url('/assets/img/backgrounds/dots-bg.webp') no-repeat center;
   background-size: cover;
   z-index: -1;
}

.insurance-type:not(:last-child) {
   margin-bottom: 60px;
}

.type-number {
   margin-right: 15px;
   font-size: 30px;
   font-weight: 700;
   color: #12be83;
}

.type-title {
   margin-bottom: 15px;
   font-size: 18px;
   font-weight: 700;
   line-height: 120%;
   color: #121B23;
   text-transform: uppercase;
}

.type-text {
   font-size: 15px;
   font-weight: 500;
   line-height: 140%;
   color: #121B23;
}

.type-text strong {
   font-weight: 700;
}



@media all and (max-width: 840px) {
   .insurance-content { grid-template-columns: 1fr; grid-template-rows: auto; }
   .types-block { flex-direction: column; align-items: center; }
   .types-block .item.first { margin-right: 0; }
   .text-content { max-width: 100%; margin-bottom: 60px; padding: 40px; }
   .i-title.types-title { text-align: center; }
}

@media all and (max-width: 650px) {
   .insurance-small-block { width: 100%; }
   .companies-block { padding: 70px 30px; }
}

@media all and (max-width: 480px) {
   .insurance-title { font-size: calc((100vw - 280px)/(480 - 280) * (40 - 30) + 30px); }
   .grid-item { padding: 40px 20px; }
   .insurance-small-block { margin: 30px auto 0 auto; }
}

@media all and (max-width: 420px) {
   .grid-item { padding: 40px 15px; }
   .insurance-text { font-size: 15px; }
   .insurance-subtitle { font-size: 16px; }
   .companies-block { padding: 70px 15px; }
   .text-content { padding: 40px 20px; }
   .text-content p { font-size: 17px; }
}

@media all and (max-width: 340px) {
   .small-block-text { font-size: 16px; }
   .insurance-type { flex-direction: column; align-items: center; padding: 20px 15px; }
   .type-number { margin-bottom: 15px; }
}
</style>