import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

import BaseLayout from "@layouts/base-layout.vue";
import PageHome from "@pages/home/home.vue";
import PageOther from "@pages/other/other.vue";
import PageSign from "@pages/sign/sign.vue";

import PageProfile from "@pages/profile/profile.vue"
import PageSettings from "@pages/settings/settings.vue"
import PageTakeAProgram from "@pages/take-a-program/take-a-program.vue"
import PageThankYou from "@pages/thank-you/thank-you.vue"
import PageAboutInsuranse from "@pages/insurance/about-insurance.vue"

/**
 * Страницы забыли пароль
 */
import PageNewPassword from "@pages/forgot-password/new-password.vue"


/**
 * Страницы из services menu
 */
import PageInsuranceForMe from "@pages/insurance/insurance-for-me/insurance-for-me.vue"
import PageInsuranceForFamily from "@pages/insurance/insurance-for-family/insurance-for-family.vue"
import PageGetMoney from "@pages/get-money/get-money.vue"

/**
 * Страницы из раздела "Полезные ссылки"
 */
import PageInsuranceEvent from "@pages/useful-links-pages/insurance-event.vue"
import PageInsuranceRules from "@pages/useful-links-pages/insurance-rules.vue"

/**
 * Страница регистрации (рефералка)
 */
import PageRegisterReferal from "@pages/register/register-referal.vue"



/**
 * Прочие статические страницы
 */
import PageLifeInsurance from "@pages/insurance/insurance-for-me/life-insurance/life-insurance.vue"
import PagePensionProvision from "@pages/insurance/insurance-for-me/life-insurance/pension-provision/pension-provision.vue"
import PageAccumulationPrograms from "@pages/insurance/insurance-for-me/life-insurance/accumulation-programs/accumulation-programs.vue"
import PageProgramE from "@pages/insurance/insurance-for-me/life-insurance/pension-provision/programs/program-e.vue"
import PageProgramESingle from "@pages/insurance/insurance-for-me/life-insurance/pension-provision/programs/program-e-single.vue"
import PageProgramPead from "@pages/insurance/insurance-for-me/life-insurance/pension-provision/programs/program-pead.vue"
import PageProgramPeSingle from "@pages/insurance/insurance-for-me/life-insurance/pension-provision/programs/program-pe-single.vue"
import PageProgramGoldCapital from "@pages/insurance/insurance-for-me/life-insurance/accumulation-programs/programs/program-gold-capital.vue"
import PageProgramCapital from "@pages/insurance/insurance-for-me/life-insurance/accumulation-programs/programs/program-capital.vue"
import PageProgramSlVip from "@pages/insurance/insurance-for-me/life-insurance/accumulation-programs/programs/program-sl-vip.vue"
import PageProgramLifePlus from "@pages/insurance/insurance-for-me/life-insurance/accumulation-programs/programs/program-life-plus.vue"

import PageInsuranceAccident from "@pages/insurance/insurance-for-me/insurance-accident/insurance-accident.vue"
import PageProgramPi from "@pages/insurance/insurance-for-me/insurance-accident/programs/program-pi.vue"
import PageProgramPiTraffic from "@pages/insurance/insurance-for-me/insurance-accident/programs/program-pi-traffic.vue"
import PageProgramBob from "@pages/insurance/insurance-for-me/insurance-accident/programs/program-bob.vue"
import PageProgramBi from "@pages/insurance/insurance-for-me/insurance-accident/programs/program-bi.vue"

import PageCriticalIllness from "@pages/insurance/insurance-for-me/critical-illness/critical-illness.vue"
import PageProgramC1 from "@pages/insurance/insurance-for-me/critical-illness/programs/program-c-1.vue"
import PageProgramC7 from "@pages/insurance/insurance-for-me/critical-illness/programs/program-c-7.vue"
import PageProgramC32 from "@pages/insurance/insurance-for-me/critical-illness/programs/program-c-32.vue"
import PageProgramW from "@pages/insurance/insurance-for-me/critical-illness/programs/program-w.vue"

import PageWomensInsurance from "@pages/insurance/insurance-for-me/womens-insurance/womens-insurance.vue"
import PageProgramFc from "@pages/insurance/insurance-for-me/womens-insurance/programs/program-fc.vue"
import PageProgramCfb from "@pages/insurance/insurance-for-me/womens-insurance/programs/program-cfb.vue"

import PageChildhoodCriticalIllness from "@pages/insurance/insurance-for-family/childhood-critical-illness/childhood-critical-illness.vue"
import PageLossOdBreadwinner from "@pages/insurance/insurance-for-family/loss-of-breadwinner/loss-of-breadwinner.vue"
import PageProgramTerm from "@pages/insurance/insurance-for-family/loss-of-breadwinner/programs/program-term.vue"
import PageProgramAdob from "@pages/insurance/insurance-for-family/loss-of-breadwinner/programs/program-adob.vue"
import PageProgramAdTraffic from "@pages/insurance/insurance-for-family/loss-of-breadwinner/programs/program-ad-traffic.vue"
import PageProgramCpa from "@pages/insurance/insurance-for-family/loss-of-breadwinner/programs/program-cpa.vue"

import PageCapitalForChildren from "@pages/insurance/insurance-for-family/capital-for-children/capital-for-children.vue"
import PageProgramChildPead from "@pages/insurance/insurance-for-family/capital-for-children/programs/program-child-pead.vue"
import PageProgramChildPeSingle from "@pages/insurance/insurance-for-family/capital-for-children/programs/program-child-pe-single.vue"

import PagePensionCapital from "@pages/insurance/insurance-for-family/pension-capital/pension-capital.vue"

import PageUsers from "@pages/users/users.vue"


/**
 * Страницы страховых компаний
 */
import PageMetLife from "@pages/companies/metlife.vue"
import PageUniqa from "@pages/companies/uniqa.vue"
import PageGrawe from "@pages/companies/grawe.vue"
import PageTaslife from "@pages/companies/taslife.vue"

import cookie from "js-cookie"



const router = new VueRouter({
  mode: "history",
  routes: [
    {
      name: "layout",
      path: "/",
      component: BaseLayout,
      children: [
        {
          name:"",
          path: "/",
          component: PageHome,
          meta: {
            title: ''
          }
        },
        {
          name: "home",
          path: "/",
          component: PageHome,
          meta: {
            title: ''
          }
        },
        {
          name: "profile",
          path: "profile",
          component: PageProfile
        },
        {
          name: "settings",
          path: "settings",
          component: PageSettings
        },
        
        /**
         * Забыли пароль
         */
        {
          name: "new-password",
          path: "new-password/:" + cookie.get('idForgotPassword'),
          component: PageNewPassword
        },

        /**
         * Страница регистрации (рефералка)
         */
        {
          name: "register-referal",
          path: "register-referal/:" + cookie.get('refferal'),
          component: PageRegisterReferal
        },
        {
          name: "register-referal",
          path: "register-referal",
          component: PageRegisterReferal
        },

        {
          name: "sign",
          path: "sign",
          component: PageSign
        },
        {
          name: "users",
          path: "users",
          component: PageUsers
        },
        {
          name: "take-a-program",
          path: "take-a-program",
          component: PageTakeAProgram,
          meta: {
            title: "Программа"
          }
        },
        {
          name: "thank-you",
          path: "thank-you",
          component: PageThankYou,
          meta: {
            title: "Программа"
          }
        },
        {
          name: "get-money",
          path: "get-money",
          component: PageGetMoney
        },
        {
          name: "about-insurance",
          path: "about-insurance",
          component: PageAboutInsuranse
        },
        /**
         * Страницы из services menu
         */
        {
          name: "insurance-for-me",
          path: "insurance-for-me",
          component: PageInsuranceForMe
        },
        {
          name: "life-insurance",
          path: "life-insurance",
          component: PageLifeInsurance,
          children: [
            
          ]
        },
        {
          name: "pension-provision",
          path: "pension-provision",
          component: PagePensionProvision
        },
        {
          name: "program-e",
          path: "program-e",
          component: PageProgramE
        },
        {
          name: "program-e-single",
          path: "program-e-single",
          component: PageProgramESingle
        },
        {
          name: "program-pead",
          path: "program-pead",
          component: PageProgramPead
        },
        {
          name: "program-pe-single",
          path: "program-pe-single",
          component: PageProgramPeSingle
        },
        {
          name: "accumulation-programs",
          path: "accumulation-programs",
          component: PageAccumulationPrograms
        },
        {
          name: "program-gold-capital",
          path: "program-gold-capital",
          component: PageProgramGoldCapital
        },
        {
          name: "program-capital",
          path: "program-capital",
          component: PageProgramCapital
        },
        {
          name: "program-sl-vip",
          path: "program-sl-vip",
          component: PageProgramSlVip
        },
        {
          name: "program-life-plus",
          path: "program-life-plus",
          component: PageProgramLifePlus
        },


        {
          name: "insurance-accident",
          path: "insurance-accident",
          component: PageInsuranceAccident
        },
        {
          name: "program-pi",
          path: "program-pi",
          component: PageProgramPi
        },
        {
          name: "program-pi-traffic",
          path: "program-pi-traffic",
          component: PageProgramPiTraffic
        },
        {
          name: "program-bob",
          path: "program-bob",
          component: PageProgramBob
        },
        {
          name: "program-bi",
          path: "program-bi",
          component: PageProgramBi
        },


        {
          name: "critical-illness",
          path: "critical-illness",
          component: PageCriticalIllness
        },
        {
          name: "program-c-1",
          path: "program-c-1",
          component: PageProgramC1
        },
        {
          name: "program-c-7",
          path: "program-c-7",
          component: PageProgramC7
        },
        {
          name: "program-c-32",
          path: "program-c-32",
          component: PageProgramC32
        },
        {
          name: "program-w",
          path: "program-w",
          component: PageProgramW
        },


        {
          name: "womens-insurance",
          path: "womens-insurance",
          component: PageWomensInsurance
        },
        {
          name: "program-fc",
          path: "program-fc",
          component: PageProgramFc
        },
        {
          name: "program-cfb",
          path: "program-cfb",
          component: PageProgramCfb
        },


        {
          name: "insurance-for-family",
          path: "insurance-for-family",
          component: PageInsuranceForFamily
        },
        {
          name: "childhood-critical-illness",
          path: "childhood-critical-illness",
          component: PageChildhoodCriticalIllness
        },
        {
          name: "loss-of-breadwinner",
          path: "loss-of-breadwinner",
          component: PageLossOdBreadwinner
        },
        {
          name: "program-term",
          path: "program-term",
          component: PageProgramTerm
        },
        {
          name: "program-adob",
          path: "program-adob",
          component: PageProgramAdob
        },
        {
          name: "program-ad-traffic",
          path: "program-ad-traffic",
          component: PageProgramAdTraffic
        },
        {
          name: "program-cpa",
          path: "program-cpa",
          component: PageProgramCpa
        },


        {
          name: "capital-for-children",
          path: "capital-for-children",
          component: PageCapitalForChildren
        },
        {
          name: "program-child-pead",
          path: "program-child-pead",
          component: PageProgramChildPead
        },
        {
          name: "program-child-pe-single",
          path: "program-child-pe-single",
          component: PageProgramChildPeSingle
        },


        {
          name: "pension-capital",
          path: "pension-capital",
          component: PagePensionCapital
        },
        
        

        /**
         * Страницы из раздела "Полезные ссылки"
         */
        {
          name: "insurance-event",
          path: "insurance-event",
          component: PageInsuranceEvent
        },
        {
          name: "insurance-rules",
          path: "insurance-rules",
          component: PageInsuranceRules
        },
        /**
         * Страницы страховых компаний
         */
        {
          name: "metlife",
          path: "metlife",
          component: PageMetLife
        },
        {
          name: "uniqa",
          path: "uniqa",
          component: PageUniqa
        },
        {
          name: "grawe",
          path: "grawe",
          component: PageGrawe
        },
        {
          name: "taslife",
          path: "taslife",
          component: PageTaslife
        },
        {
          name:"other",
          path: "other/:id?",
          component: PageOther
        }
      
        // {
        //   path: "Новости",
        //   component: EmptyLayout,
        //   children:[
        //     {
        //       name: "news",
        //       path: "",
        //       component: PageNews,
        //       meta: {
        //         title: "Новости"
        //       }
        //     },
        //     {
        //       name: "news-detail",
        //       path: ":code",
        //       component: PageNewsDetail
        //     }
        //   ]
        // },
        
      ]
    }
    // {
    //     name: loginRoute.name,
    //     path: "/" + routeLangPrefix + "/login",
    //     component: LoginComponent,
    //     meta: {
    //         allowAnonymous: true,
    //         title: "Авторизация"
    //     }
    // },
    // {
    //     name: '404',
    //     path: "*",
    //     component: LoginComponent,
    //     meta: {
    //         allowAnonymous: true,
    //         title: "Авторизация"
    //     }
    // },
  ]
});

router.beforeEach((to, from, next) => {
  // console.log(to, from, next);
  // var title = Vue.$mainStore.PageTitle;
  // if (to.meta.title) {
  //   if (title) title = `${to.meta.title} | ${title}`;
  //   else title = to.meta.title;
  // }
  // document.title = title;
  // console.log("document.head.title", document.head.title);
    next();
});

export default router;
