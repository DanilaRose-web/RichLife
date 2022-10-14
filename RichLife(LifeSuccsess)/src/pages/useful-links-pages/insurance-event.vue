<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch">
      <template slot="header">
         <minimal-header-metlife @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />

         <!-- <services-static-menu>
            <ul class="static-menu">
               <li><router-link to="">Связаться с нами</router-link></li>
               <li><router-link to="">Оплата страхового взноса</router-link></li>
               <li><router-link to="">Бланки и формы заявлений</router-link></li>
               <li><router-link to="">Сроки обработки типовых запросов</router-link></li>
               <li><router-link to="">Персональные данные</router-link></li>
               <li><router-link to="">Дожития</router-link></li>
               <li><router-link to="">Налоговая скидка</router-link></li>
            </ul>
         </services-static-menu> -->
      </template>

      <breadcrumbs>
         <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <router-link to="metlife">MetLife <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <span>Страховое событие</span>
      </breadcrumbs>

      <section class="section-insurance-event i-section">
         <i-container>
            <span class="i-title dancing">Insurance Event</span>
            <h1 class="i-title section-title">Страховое событие</h1>
            <h5 class="i-subtitle">В этом разделе мы старались максимально подробно описать процесс подачи заявления на страховую выплату и список документов, который понадобится собрать и предоставить в компанию</h5>
         
            <div class="insurance-steps">
               <div class="insurance-step one">
                  <div class="watermark">01</div>
                  <h5 class="step-title">ШАГ 1</h5>
                  <p class="step-text">Заполните заявление. Вы можете сделать это, перейдя по <a href="" target="blank">ссылке</a></p>
               </div>

               <div class="insurance-step two">
                  <div class="watermark">02</div>
                  <h5 class="step-title">ШАГ 2</h5>
                  <p class="step-text">Соберите пакет необходимых документов.</p>
                  <p class="step-text">Список документов указано в заявлении под пунктом №6 "Приложения".</p>
                  <p class="step-text">Если Вы не нашли информацию о необходимых документах, выберите соответствующую ссылку из списка, представленном в конце данной страницы</p>
                  <p class="step-text">Обращаем Ваше внимание, что медицинский документ должен быть предоставлен в оригинале или в виде копии, заверенной медицинским учреждением.</p>
                  <p class="step-text">Проверяйте правильность написания личных данных и диагноза, а также наличие штампа и печати больнице!</p>
                  <p class="step-text"><a href="" target="blank">Смотрите пример правильно оформленного медицинского документа</a>  (форма может быть любой).</p>
               </div>

               <div class="insurance-step three">
                  <div class="watermark">03</div>
                  <h5 class="step-title">ШАГ 3</h5>
                  <p class="step-text">Отправьте пакет документов вместе с заявлением в течение 10 календарных дней на почтовый адрес: ЗАО "МетЛайф" Отдел урегулирования страховых случаев, м. Киев, 01032, Украина, ул. Жилянская, 110, БЦ «Карат» или сканированную копию на электрону адрес <a href="mailto:claims@metlife.ua">claims@metlife.ua</a> или <a href="mailto:office@metlife.ua">office@metlife.ua</a> (ЧАО "МетЛайф" оставляет за собой право запросить оригинал документов).</p>
                  <p class="step-text">Официальный рассмотрение дела начинается только после получения Компанией оригинала Вашего письменного заявления.  </p>
                  <div class="warning-block">
                     <div class="warning-icon">
                        <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-warning"></use></svg>
                     </div>

                     <ul class="i-ul-list warning">
                        <li>Пожалуйста, убедитесь, что все документы, касающиеся Вашего случая, оформленны на украинском или русском языках.</li>
                        <li>Если случай произошел за пределами Украины, и Ваши документы оформлены не на русском и украинском языках, такие документы должны быть предоставлены в виде легализованных переводов, заверенных апостилем.</li>
                        <li>В некоторых случаях мы можем попросить другую дополнительную информацию или требовать прохождения Вами медицинского обследования в одном из консультативных центров Компании до момента принятия окончательного решения о Вашем случае. О чем мы обязательно Вам сообщим.</li>
                        <li>Для удобной и быстрой обработки Вашего обращения, пожалуйста, внимательно выполняйте вышеуказанные рекомендации, иначе, рассмотрение Вашего обращения может быть отсрочено (или вероятно принято решение об отказе в рассмотрении случая и / или осуществлении страховой выплаты).</li>
                     </ul>
                  </div>
               </div>
            </div>
         </i-container>
      </section>

      <section class="section-insurance-docs">
         <i-container>
            <h2 class="i-title insurance-docs-title">Перечень необходимых документов для дальнейшего рассмотрения вашего дела</h2>

            <div class="insurance-docs">
               <ul class="insurance-docs-list">
                  <li>
                     <h4 class="list-title">
                        Как получить выплату по страховому случаю, который произошел в результате несчастного случая.
                        <svg class="icon-list-arrow"><use xlink:href="/assets/img/svg-sprite.svg#icon-arrow-right"></use></svg>
                     </h4>
                     <div class="list-content">
                        <p class="step-text mt fw600">Нетрудоспособность в результате несчастного случая / Переломы или ожоги / Телесные повреждения Госпитализация / Госпитализация / Хирургическое вмешательство</p>
                        <!-- 01 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>01</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text no-mb">Заполните заявление о страховой выплате.</p>
                           </div>
                        </div>

                        <!-- 02 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>02</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text"><strong>Подготовьте следующие документы:</strong> </p>
                           
                              <ul class="i-ul-list step-ul smaller-mb-li">
                                 <li>Медицинские справки из медицинского учреждения с указанием диагноза на дату события и даты госпитализации (оригинал или копия, заверенная учреждением, выдавшим документ).</li>
                                 <li>Справка из полиции (оригинал или копия, заверенная учреждением, который выдавал документ, по требованию Страховщика).</li>
                              </ul>
                           </div>
                        </div>

                        <!-- 03 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>03</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text"><strong>Сформируйте пакет документов, убедитесь, что все оформлено правильно:</strong> </p>
                           
                              <ul class="i-ul-list step-ul mb smaller-mb-li">
                                 <li>Все личные данные указаны без ошибок</li>
                                 <li>Документы оформлении должным образом - налицо штампы и печати.</li>
                                 <li>Все документы, касающиеся страхового события, должны быть оформлены на украинском или русском языках</li>
                                 <li>Если случай произошел за пределами Украины, и документы оформлены на иностранном языке (не на украинском или русском), такие документы должны быть предоставлены в виде легализованных переводов, заверенных апостилем.</li>
                              </ul>

                              <p class="step-text">В некоторых случаях можем попросить другую дополнительную информацию. О чем мы обязательно сообщим Клиенту.</p>
                              <p class="step-text"><strong>Бумажные оригиналы предоставьте по адресу :</strong></p>
                              <p class="step-text">ЗАО «МетЛайф», Отдел урегулирования страховых случаев, 01032, г.. Киев, ул. Жилянская д. 110Сканированную копию направляйте:  claims@metlife.ua; Ukraine - client.request client.request@metlife.ua</p>
                           </div>
                        </div>

                        <!-- 04 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>04</span> ШАГ</div>
                           <div class="content-step-info">
                              <ul class="i-ul-list step-ul mb smaller-mb-li">
                                 <li>Получение и проверка ВСЕХ ДОКУМЕНТОВ</li>
                                 <li>Принятие решения</li>
                                 <li>Расчет суммы страховой выплаты - в случае принятия положительного решения</li>
                              </ul>

                              <p class="step-text"><strong>Отказ возможен если:</strong></p>
                             
                              <ul class="i-ul-list step-ul mb smaller-mb-li">
                                 <li>Не представлены в установленные сроки документы являются причиной для отказа независимо от наличия / отсутствия звонка</li>
                                 <li>Не является страховым случаем</li>
                                 <li>Невыполнение условий Договора страхования жизни</li>
                                 <li>«Исключение из страховых случаев и ограничения страхования» Правил добровольного страхования жизни ЧАО «МетЛайф»</li>
                              </ul>
                           </div>
                        </div>

                        <!-- 05 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>05</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text">Перечисление страховой выплаты на личный расчетный счет в банке - сообщить в Компанию при подаче заявления на осуществление страховой выплаты</p>
                              <p class="step-text">Перечисление страховой выплаты по имени получателя по системе «Аваль-Экспресс» в АО «Райффайзен Банк».</p>
                              <p class="step-text no-mb"><strong>Кроме того, компания оставляет за собой право попросить другие документы, необходимые при рассмотрении дела.</strong></p>
                           </div>
                        </div>
                     </div>
                  </li>

                  <li>
                     <h4 class="list-title">
                        Как получить выплату по страховому случаю, который произошел из-за болезни.
                        <svg class="icon-list-arrow"><use xlink:href="/assets/img/svg-sprite.svg#icon-arrow-right"></use></svg>
                     </h4>
                     <div class="list-content">
                        <p class="step-text mt fw600">Диагностирования критического заболевания. Госпитализация / Хирургическое вмешательство. Освобождение от уплаты страховых премий (Неработоспособность вследствие болезни). Заявитель Застрахованное лицо или Страхователь, если Застрахованное лицо несовершеннолетний ребенок</p>

                        <!-- 01 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>01</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text no-mb">Заполните заявление о страховой выплате.</p>
                           </div>
                        </div>

                        <!-- 02 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>02</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text"><strong>Подготовьте медицинские документы:</strong> </p>
                           
                              <ul class="i-ul-list step-ul smaller-mb-li">
                                 <li>Медицинские справки из медицинского учреждения с указанием диагноза на дату события и даты госпитализации (оригинал или копия, заверенная учреждением, выдавшим документ).</li>
                                 <li>Справка из полиции (оригинал или копия, заверенная учреждением, который выдавал документ).</li>
                                 <li>Справка о присвоении застрахованному лицу группы инвалидности, в случае такого присвоения, с указанием выводу о рекомендуемые условия и характер труда (оригинал или копия, заверенная учреждением, выдавшим документ).</li>
                                 <li>Медицинская карта амбулаторного больного застрахованного лица (оригинал - по дополнительной требованию Страховщика).</li>
                              </ul>
                           </div>
                        </div>

                        <!-- 03 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>03</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text"><strong>Сформируйте пакет документов, убедитесь, что все оформлено правильно:</strong> </p>
                           
                              <ul class="i-ul-list step-ul mb smaller-mb-li">
                                 <li>Все личные данные указаны без ошибок</li>
                                 <li>Документы оформлении должным образом - налицо штампы и печати.</li>
                                 <li>Все документы, касающиеся страхового события, должны быть оформлены на украинском или русском языках</li>
                                 <li>Если случай произошел за пределами Украины, и документы оформлены на иностранном языке (не на украинском или русском), такие документы должны быть предоставлены в виде легализованных переводов, заверенных апостилем.</li>
                              </ul>

                              <p class="step-text">В некоторых случаях можем попросить другую дополнительную информацию. О чем мы обязательно сообщим Клиенту.</p>
                              <p class="step-text"><strong>Бумажные оригиналы предоставьте по адресу :</strong></p>
                              <p class="step-text">ЗАО «МетЛайф», Отдел урегулирования страховых случаев, 01032, г.. Киев, ул. Жилянская д. 110Сканированную копию направляйте:  claims@metlife.ua; Ukraine - client.request client.request@metlife.ua</p>
                           </div>
                        </div>

                        <!-- 04 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>04</span> ШАГ</div>
                           <div class="content-step-info">
                              <ul class="i-ul-list step-ul mb smaller-mb-li">
                                 <li>Получение и проверка ВСЕХ ДОКУМЕНТОВ</li>
                                 <li>Принятие решения</li>
                                 <li>Расчет суммы страховой выплаты - в случае принятия положительного решения</li>
                              </ul>

                              <p class="step-text"><strong>Отказ возможен если:</strong></p>
                             
                              <ul class="i-ul-list step-ul mb smaller-mb-li">
                                 <li>Не представлены в установленные сроки документы являются причиной для отказа независимо от наличия / отсутствия звонка</li>
                                 <li>Не является страховым случаем</li>
                                 <li>Невыполнение условий Договора страхования жизни</li>
                                 <li>«Исключение из страховых случаев и ограничения страхования» Правил добровольного страхования жизни ЧАО «МетЛайф»</li>
                              </ul>
                           </div>
                        </div>

                        <!-- 05 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>05</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text">Перечисление страховой выплаты на личный расчетный счет в банке - сообщить в Компанию при подаче заявления на осуществление страховой выплаты</p>
                              <p class="step-text">Перечисление страховой выплаты по имени получателя по системе «Аваль-Экспресс» в АО «Райффайзен Банк».</p>
                              <p class="step-text no-mb"><strong>Кроме того, компания оставляет за собой право попросить другие документы, необходимые при рассмотрении дела.</strong></p>
                           </div>
                        </div>
                     </div>
                  </li>

                  <li>
                     <h4 class="list-title">
                        Смерть Застрахованного лица в результате несчастного случая
                        <svg class="icon-list-arrow"><use xlink:href="/assets/img/svg-sprite.svg#icon-arrow-right"></use></svg>
                     </h4>
                     <div class="list-content">
                        <p class="step-text mt fw600">Перечень документов, необходимых для рассмотрения события, связанного со смертью застрахованного лица в результате несчастного случая</p>

                        <!-- 01 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>01</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text no-mb">Заполните заявление о страховой выплате. В случае смерти ЗЛ заявителем выступает выгодоприобретатель, законный представитель или наследник</p>
                           </div>
                        </div>

                        <!-- 02 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>02</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text"><strong>Подготовьте медицинские документы:</strong> </p>
                           
                              <ul class="i-ul-list step-ul smaller-mb-li">
                                 <li>Оригинал страхового полиса и приложений к нему.</li>
                                 <li>Оригинал или нотариально заверенная копия Свидетельства о смерти.</li>
                                 <li>Справка о причине смерти и / или врачебное свидетельство о смерти (копия).</li>
                                 <li>Ксерокопии всех страниц паспорта и справки о присвоении идентификационного номера налогоплательщика (идентификационный код) выгодоприобретателя (-ов), заверенные собственноручно. Если выгодоприобретателем является малолетнее лицо - по перечню необходимых для предоставления документов обратитесь, пожалуйста, в Отдел урегулирования страховых случаев.</li>
                                 <li>Документ, удостоверяющий степень родства выгодоприобретателя (-ов) с застрахованным лицом / страхователем (свидетельство о браке, свидетельство о рождении и т.п.) - копия.</li>
                                 <li>Справка из полиции (оригинал или копия, заверенная учреждением, который выдавал документ).</li>
                              </ul>
                           </div>
                        </div>

                        <!-- 03 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>03</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text"><strong>Сформируйте пакет документов, убедитесь, что все оформлено правильно:</strong> </p>
                           
                              <ul class="i-ul-list step-ul mb smaller-mb-li">
                                 <li>Все личные данные указаны без ошибок</li>
                                 <li>Документы оформлении должным образом - налицо штампы и печати.</li>
                                 <li>Все документы, касающиеся страхового события, должны быть оформлены на украинском или русском языках</li>
                                 <li>Если случай произошел за пределами Украины, и документы оформлены на иностранном языке (не на украинском или русском), такие документы должны быть предоставлены в виде легализованных переводов, заверенных апостилем.</li>
                              </ul>

                              <p class="step-text">В некоторых случаях можем попросить другую дополнительную информацию. О чем мы обязательно сообщим Клиенту.</p>
                              <p class="step-text"><strong>Бумажные оригиналы предоставьте по адресу :</strong></p>
                              <p class="step-text">ЗАО «МетЛайф», Отдел урегулирования страховых случаев, 01032, г.. Киев, ул. Жилянская д. 110Сканированную копию направляйте:  claims@metlife.ua; Ukraine - client.request client.request@metlife.ua</p>
                           </div>
                        </div>

                        <!-- 04 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>04</span> ШАГ</div>
                           <div class="content-step-info">
                              <ul class="i-ul-list step-ul mb smaller-mb-li">
                                 <li>Получение и проверка ВСЕХ ДОКУМЕНТОВ</li>
                                 <li>Принятие решения</li>
                                 <li>Расчет суммы страховой выплаты - в случае принятия положительного решения</li>
                              </ul>

                              <p class="step-text"><strong>Отказ возможен если:</strong></p>
                             
                              <ul class="i-ul-list step-ul mb smaller-mb-li">
                                 <li>Не представлены в установленные сроки документы являются причиной для отказа независимо от наличия / отсутствия звонка</li>
                                 <li>Не является страховым случаем</li>
                                 <li>Невыполнение условий Договора страхования жизни</li>
                                 <li>«Исключение из страховых случаев и ограничения страхования» Правил добровольного страхования жизни ЧАО «МетЛайф»</li>
                              </ul>
                           </div>
                        </div>

                        <!-- 05 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>05</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text">Перечисление страховой выплаты на личный расчетный счет в банке - сообщить в Компанию при подаче заявления на осуществление страховой выплаты</p>
                              <p class="step-text">Перечисление страховой выплаты по имени получателя по системе «Аваль-Экспресс» в АО «Райффайзен Банк».</p>
                              <p class="step-text no-mb"><strong>Кроме того, компания оставляет за собой право попросить другие документы, необходимые при рассмотрении дела.</strong></p>
                           </div>
                        </div>
                     </div>
                  </li>

                  <li>
                     <h4 class="list-title">
                        Смерть Застрахованного лица вследствие заболевания
                        <svg class="icon-list-arrow"><use xlink:href="/assets/img/svg-sprite.svg#icon-arrow-right"></use></svg>
                     </h4>
                     <div class="list-content">
                        <p class="step-text mt fw600">Перечень документов, необходимых для рассмотрения события, связанного со смертью застрахованного лица в результате болезни.</p>

                        <!-- 01 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>01</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text no-mb">Заполните заявление о страховой выплате. В случае смерти ЗЛ заявителем выступает выгодоприобретатель, законный представитель или наследник</p>
                           </div>
                        </div>

                        <!-- 02 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>02</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text"><strong>Подготовьте медицинские документы:</strong> </p>
                           
                              <ul class="i-ul-list step-ul smaller-mb-li">
                                 <li>Оригинал страхового полиса и приложений к нему.</li>
                                 <li>Оригинал или нотариально заверенная копия Свидетельства о смерти.</li>
                                 <li>Справка о причине смерти и / или врачебное свидетельство о смерти (копия).</li>
                                 <li>Ксерокопии всех страниц паспорта и справки о присвоении идентификационного номера налогоплательщика (идентификационный код) выгодоприобретателя (-ов), заверенные собственноручно. Если выгодоприобретателем является малолетнее лицо - по перечню необходимых для предоставления документов обратитесь, пожалуйста, в Отдел урегулирования страховых случаев.</li>
                                 <li>Документ, удостоверяющий степень родства выгодоприобретателя (-ов) с застрахованным лицом / страхователем (свидетельство о браке, свидетельство о рождении и т.п.) - копия.</li>
                                 <li>Медицинская карта амбулаторного больного застрахованного лица (по дополнительному запросу Страховщика).</li>
                              </ul>
                           </div>
                        </div>

                        <!-- 03 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>03</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text"><strong>Сформируйте пакет документов, убедитесь, что все оформлено правильно:</strong> </p>
                           
                              <ul class="i-ul-list step-ul mb smaller-mb-li">
                                 <li>Все личные данные указаны без ошибок</li>
                                 <li>Документы оформлении должным образом - налицо штампы и печати.</li>
                                 <li>Все документы, касающиеся страхового события, должны быть оформлены на украинском или русском языках</li>
                                 <li>Если случай произошел за пределами Украины, и документы оформлены на иностранном языке (не на украинском или русском), такие документы должны быть предоставлены в виде легализованных переводов, заверенных апостилем.</li>
                              </ul>

                              <p class="step-text">В некоторых случаях можем попросить другую дополнительную информацию. О чем мы обязательно сообщим Клиенту.</p>
                              <p class="step-text"><strong>Бумажные оригиналы предоставьте по адресу :</strong></p>
                              <p class="step-text">ЗАО «МетЛайф», Отдел урегулирования страховых случаев, 01032, г.. Киев, ул. Жилянская д. 110Сканированную копию направляйте:  claims@metlife.ua; Ukraine - client.request client.request@metlife.ua</p>
                           </div>
                        </div>

                        <!-- 04 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>04</span> ШАГ</div>
                           <div class="content-step-info">
                              <ul class="i-ul-list step-ul mb smaller-mb-li">
                                 <li>Получение и проверка ВСЕХ ДОКУМЕНТОВ</li>
                                 <li>Принятие решения</li>
                                 <li>Расчет суммы страховой выплаты - в случае принятия положительного решения</li>
                              </ul>

                              <p class="step-text"><strong>Отказ возможен если:</strong></p>
                             
                              <ul class="i-ul-list step-ul mb smaller-mb-li">
                                 <li>Не представлены в установленные сроки документы являются причиной для отказа независимо от наличия / отсутствия звонка</li>
                                 <li>Не является страховым случаем</li>
                                 <li>Невыполнение условий Договора страхования жизни</li>
                                 <li>«Исключение из страховых случаев и ограничения страхования» Правил добровольного страхования жизни ЧАО «МетЛайф»</li>
                              </ul>
                           </div>
                        </div>

                        <!-- 05 шаг -->
                        <div class="content-step">
                           <div class="content-step-title"><span>05</span> ШАГ</div>
                           <div class="content-step-info">
                              <p class="step-text">Перечисление страховой выплаты на личный расчетный счет в банке - сообщить в Компанию при подаче заявления на осуществление страховой выплаты</p>
                              <p class="step-text">Перечисление страховой выплаты по имени получателя по системе «Аваль-Экспресс» в АО «Райффайзен Банк».</p>
                              <p class="step-text no-mb"><strong>Кроме того, компания оставляет за собой право попросить другие документы, необходимые при рассмотрении дела.</strong></p>
                           </div>
                        </div>
                     </div>
                  </li>
               </ul>
            </div>
         </i-container>
      </section>

      <section class="section-warning">
         <i-container :maxWidth="'1130px'">
            <div class="warning-block">
               <div class="warning-icon">
                  <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-warning"></use></svg>
               </div>

               <ul class="i-ul-list warning">
                  <li>Для рассмотрения страхового события по вашему договору страхования, нам необходимы <strong>документы на украинском или русском языке</strong></li>
                  <li>Если документы составлены на иностранном языке (например, если страховое событие наступила за границей), то они должны быть переведены на украинский и заверенные нотариально или с апостилем.</li>
                  <li>Все копии медицинских документов удостоверяются медицинскими учреждениями, выдали их или приняли оригиналы на хранение. Остальные документы заверяются органами, выдают документ (полиция, прокуратура, ЗАГС, суд и т.д.), или нотариусом</li>
               </ul>
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

      <modal-chat :innerOpen="openChat" @closeChat="onCloseChat"></modal-chat>
   </layout>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

import cookie from "js-cookie"

@Component
export default class PageInsuranceEventComponents extends Vue {

   showJoinModal: boolean = false  // флаг на открытие формы join
   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false
   noteGetInTouch: boolean = false // фдаг на открытие окна с проверкой на авторизацию


   created() {
      if (cookie.get('token') == undefined)
         this.$router.push({ name: 'sign' })
   }

   mounted() {
      this.initjQueryAccordion()
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

   initjQueryAccordion() {
      $('.list-content').hide()

      $('.insurance-docs li').on('click', function () {
         $('.insurance-docs li').not($(this)).removeClass('show')
         $('.list-content').not($(this).children('.list-content')).slideUp()
         $(this).toggleClass('show').children('.list-content').slideToggle();
      })
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




/* Блок первый (шаги) 
================================================================================= */
.insurance-steps {
   margin: 80px auto 0 auto;
   max-width: 900px;
}

.insurance-step {
   margin-bottom: 80px;
   padding: 30px 50px;
   position: relative;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
   background: #F8F9FC;
   border-radius: 15px;
}

.insurance-step::before {
   content: '';
   position: absolute;
   top: -30px;
   left: -30px;
   width: 70px;
   height: 70px;
   background: url('/assets/img/backgrounds/dots-bg-red.webp') no-repeat center;
   background-size: cover;
   z-index: -1;
}

.insurance-step .watermark {
   position: absolute;
   top: 5px;
   left: 5px;
   font-size: 130px;
   font-weight: 700;
   color: rgba(230, 230, 235, 0.2);
   user-select: none;
}

.insurance-step .step-title {
   margin-bottom: 15px;
   font-size: 25px;
   font-weight: 700;
   line-height: 120%;
   text-align: center;
}

.step-text {
   margin-bottom: 15px;
   font-size: 14px;
   font-weight: 500;
   line-height: 160%;
   color: #121B23;
}

.step-text.no-mb {
   margin-bottom: 0;
}

.step-text.fw600 {
   font-weight: 600;
}

.step-text.mt {
   margin-top: 15px;
}

.step-text strong {
   font-weight: 700;
}

.step-text a {
   font-weight: 600;
   color: #12be83;
}

.step-text a:hover {
   color: #0da671;
   text-decoration: underline;
}

/* .insurance-step.one {
   border-right: 1px solid #12be83;
   border-bottom: 1px solid #12be83;
} */

.insurance-step.one::before {
   background: url('/assets/img/backgrounds/dots-bg.webp') no-repeat center;
   background-size: cover;
}

.insurance-step.one .step-title {
   color: #12be83;
}

.insurance-step.one .step-text {
   text-align: center;
}

.insurance-step.one .watermark {
   color: #12be83;
   opacity: 0.1;
}







/* .insurance-step.two {
   border-right: 1px solid #FACDD4;
   border-bottom: 1px solid #FACDD4;
} */

.insurance-step.two::before {
   background: url('/assets/img/backgrounds/dots-bg-pink.webp') no-repeat center;
   background-size: cover;
}

.insurance-step.two .step-title {
   color: #FACDD4;
}

.insurance-step.two .watermark {
   color: #FACDD4;
   opacity: 0.3;
}








/* .insurance-step.three {
   border-right: 1px solid #B10444;
   border-bottom: 1px solid #B10444;
} */

.insurance-step.three::before {
   background: url('/assets/img/backgrounds/dots-bg-red.webp') no-repeat center;
   background-size: cover;
}

.insurance-step.three .step-title {
   color: #B10444;
}

.insurance-step.three .watermark {
   color: #B10444;
   opacity: 0.1;
}









/* insurance-docs (аккордион) 
==================================================================================*/
.section-insurance-docs {
   padding-bottom: 60px;
}

.insurance-docs-title {
   margin: 0 auto 30px auto;
   text-transform: none;
   font-size: 30px;
   line-height: 115%;
   max-width: 900px;
}

.insurance-docs {
   margin: 0 auto;
   max-width: 1100px;
   /* padding: 40px; */
   border-radius: 15px;
   /* box-shadow: 0 0 20px rgba(0, 0, 0, 0.1); */
}

.insurance-docs-list > li {
   position: relative;
   background: #fff;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
   border-radius: 15px;
   z-index: 0;
}

.insurance-docs-list > li:not(:last-child) {
   margin-bottom: 10px;
}

.list-title {
   padding: 10px 30px 10px 15px;
   font-size: 16px;
   font-weight: 600;
   line-height: 150%;
   color: #121B23;
   border-radius: 15px;
   cursor: pointer;
   position: relative;
   transition: all 0.3s ease-out;
}

.insurance-docs-list > li.show .list-title,
.insurance-docs-list > li:hover .list-title {
   background: #12be83;
   color: #fff;
}

.list-title .icon-list-arrow {
   position: absolute;
   right: 10px;
   top: 50%;
   transform: translateY(-50%);
   width: 15px;
   height: 15px;
   fill: #121B23;
   transition: all 0.3s ease-out;
}

.insurance-docs-list > li:hover .icon-list-arrow {
   fill: #fff;
}

.insurance-docs-list > li.show .icon-list-arrow {
   fill: #fff;
   transform: translateY(-50%) rotate(90deg);
}

.list-content {
   padding: 5px 25px 15px 25px;
}

.content-step {
   margin-top: 50px;
   padding: 20px 30px;
   position: relative;
   background: #F8F9FC;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
   border-radius: 15px;
}

.content-step::before {
   content: '';
   position: absolute;
   top: -20px;
   left: 50%;
   transform: translateX(-50%);
   width: 58px;
   height: 58px;
   background: url('/assets/img/backgrounds/dots-bg.webp') no-repeat center;
   background-size: cover;
   opacity: 0.1;
}

.content-step-title {
   margin-bottom: 10px;
   display: flex;
   align-items: center;
   font-size: 25px;
   font-weight: 700;
   line-height: 120%;
   color: #121B23;
   text-transform: uppercase;
}

.content-step-title span {
   margin-right: 15px;
   display: inline-block;
   font-size: 25px;
   font-weight: 700;
   color: #12be83;
}







/* последня секция (внимание) */
.section-warning {
   padding-bottom: 60px;
}






@media all and (max-width: 550px) {
   .list-title { font-size: 14px; }
}

@media all and (max-width: 500px) {
   .insurance-step { padding: 30px 20px; }
   .content-step { padding: 20px 15px; }
   .list-content { padding: 5px 15px 15px 15px; }
}

@media all and (max-width: 400px) {
   .i-ul-list.step-ul li { font-size: 13px; }
}

@media all and (max-width: 350px) {
   .insurance-step { padding: 30px 15px; }
}

</style>