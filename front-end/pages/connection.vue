<template>
  <div class="app-container">
    <div class="df">
      <div class="appNavigation">
      </div>
      <div class="page-container">
        
        <div class="title relative items-center ">
          <div class="col">
            <NavBar/>
          </div>
        </div>
        <div class="fg1 pt6x">
          <main class="h-full">
            <div class="row h-full">
              <div class="h-full col-3">
                <div class="h-full fg1 relative flex flex-col rounded-2xl b-card shadow-lg">
                  <div class="p6x flex fg1 flex-col">
                    <div class="h-full flex flex-col">
                      <div class="flex items-center justify-between">
                        <h2>Connection manager</h2>
                      </div>
                      <Loading v-if="state.isServersLoading"/>
                      <Servers
                        :servers="state.servers"
                        @onClickServer="getServerFocused($event)"
                      />
                    </div>
                  </div>
                </div>
              </div>
              <div class="h-full col">
                <div class="h-full fg1 flex relative flex-col b-card shadow-xl rounded-2xl">
                  <div class="b-card__header p6x shadow-md">
                    <div>
                      <textarea id="my-textarea" rows="2" placeholder="localhost" v-model = "state.connectionString"></textarea>
                    </div>
                  </div>
                  <div class="b-card__body px-0 pt-0 flex flex-col p6x fg1">
                    <div class="h-full flex flex-col">
                      <div class="mt-2 flex fg1 flex-col">
                        <div class="">
                          <div class="flex justify-center">
                            <button class="px-4 py-2 border-b-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setActiveTab(1)" :class="{'border-indigo-500 text-indigo-600': activeTab === 1}">
                              General
                            </button>
                            <button class="px-4 py-2 border-b-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setActiveTab(2)" :class="{'border-indigo-500 text-indigo-600': activeTab === 2}">
                              Authentication
                            </button>
                            <button class="px-4 py-2 border-b-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setActiveTab(3)" :class="{'border-indigo-500 text-indigo-600': activeTab === 3}">
                              Proxy/ SSH
                            </button>
                          </div>
                          <Loading v-if="state.isServerInfoLoading"/>
                          <div v-if="activeTab === 1">
                            <General 
                              
                              :general = "inputModel.generalModel"
                              @update:general="updateGeneral"
                              @update:objectGeneral="updateObjectGeneral"
                              @update:directConnection="renderConnectionString"
                            />
                          </div>
                          <div v-if="activeTab === 2">
                            <Authentication 
                              :tabAuth="state.tabAuth"
                              :authentication="inputModel.authenticationModel"
                              @update:objectAuthentication="updateObjectAuth"
                              @update:usingAuth="updateUsingAuth"
                              @update:objectMechanismAuth="updateMechanismAuth"
                              @update:renderConnection="renderConnectionString"
                            />
                          </div>
                          <div v-if="activeTab === 3">
                            <Proxy 
                              :proxy="inputModel.proxyModel"
                              @update:noneMethod="updateObjectProxy"
                              @update:method="updateMethodProxy"
                            />
                          </div>
                          <div class="submit">
                            <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded w-28" @click="handleClickSubmitBtn">
                              Save
                            </button>
                            <button class="bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded" v-if="inputModel.inputServerModel.id" @click="deleteServer">
                              Delete
                            </button>
                            <input
                              v-model="inputModel.inputServerModel.name"
                              type="text"
                              autocomplete="off"
                              placeholder="Give name server here..."
                              class="b-input__inner shadow-md"
                              fdprocessedid="ulryzn"
                            />
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </main>
        </div>
      </div>
    </div>
    <loading-overlay :isLoading="state.isLoading" />
  </div>
</template>

<script setup lang="ts">
//@ts-ignore
  import General from "../components/General/General.vue"
  import Authentication from "../components/Authentication/Authentication.vue"
  import Proxy from "../components/Proxy/Proxy.vue"
  import Servers from "../components/Servers/Servers.vue"
  import NavBar from "../components/NavBar/NavBar.vue"
  import LoadingOverlay from "../components/LoadingOverlay/LoadingOverlay.vue"
  import Loading from "../components/Loading/Loading.vue"
  import { onMounted } from 'vue'
  import axios from 'axios'
  import { ref } from 'vue';

  const activeTab = ref(1);
  
  const inputModel = reactive({
    inputServerModel: {
      name: "",
      isUseAuthentication: false,
      isUseProxy: false,
    },
    generalModel: {
      isDirectConnection: false,
      isIncludeSrv: false,
      host: 'localhost:27017',
    },
    authenticationModel: {
      isDefault: false,
      isSHA1: false,
      isSHA256: false,
      username: '',
      password: '',
      authDatabase: '',
    },
    proxyModel: {
      isWithPass: false,
      isWithIdentityFile: false,
      isSocks5: false,
      hostName: '',
      port: 0,
      sshUserName: '',
      sshPassword: '',
    }
  })

  const defaultInputModel = {
    inputServerModel: {
      name: "",
      isUseAuthentication: false,
      isUseProxy: false,
    },
    generalModel: {
      isDirectConnection: false,
      isIncludeSrv: false,
      host: 'localhost:27017',
    },
    authenticationModel: {
      isDefault: false,
      isSHA1: false,
      isSHA256: false,
      username: '',
      password: '',
      authDatabase: '',
    },
    proxyModel: {
      isWithPass: false,
      isWithIdentityFile: false,
      isSocks5: false,
      hostName: '',
      port: 0,
      sshUserName: '',
      sshPassword: '',
    }
  }

  const state = reactive({
    connectionString: `mongodb://${inputModel.generalModel.host}/`,
    srv:'',
    direct:'',
    auth: '',
    authSource: '',
    tabAuth: 1,
    tabProxy: 1,
    isLoading: false,
    isServersLoading: false,
    isServerInfoLoading: false,
    serverFocused: 0,
    servers: [],
    mechanism: ''
  })

  function resetServerInfo() {
    inputModel.inputServerModel = defaultInputModel.inputServerModel;
    inputModel.generalModel = defaultInputModel.generalModel;
    inputModel.authenticationModel = defaultInputModel.authenticationModel;
    inputModel.proxyModel = defaultInputModel.proxyModel;
    state.connectionString = `mongodb://${inputModel.generalModel.host}/`
    state.serverFocused= 0
  }

  function percentEncode(str) {
    return encodeURIComponent(str).replace(/[!'()*]/g, function(c) {
      return '%' + c.charCodeAt(0).toString(16);
    });
  }

  function updateGeneral(value: string) {
    if (inputModel.generalModel.isIncludeSrv == true) {
      inputModel.generalModel.host = value
      renderConnectionString()
    }
    else {
      inputModel.generalModel.host = value
      renderConnectionString()
    }

  }

  function updateObjectGeneral(object: object) {
    inputModel.generalModel.isDirectConnection = object.isDirectConnection == undefined ? inputModel.generalModel.isDirectConnection : object.isDirectConnection
    inputModel.generalModel.isIncludeSrv = object.isIncludeSrv
  }

  function updateObjectAuth(object: object) {
    inputModel.inputServerModel.isUseAuthentication = object.isUsed;
    inputModel.authenticationModel.isDefault = object.isDefault
    inputModel.authenticationModel.isSHA1 = object.isSHA1
    inputModel.authenticationModel.isSHA256 = object.isSHA256
    inputModel.authenticationModel.username = object.username
    inputModel.authenticationModel.password = object.password
    inputModel.authenticationModel.authDatabase = object.authDatabase
    state.mechanism = ''
    state.tabAuth = object.tabAuth
    renderConnectionString();
  }

  function updateUsingAuth(object: object) {
    inputModel.inputServerModel.isUseAuthentication = object.isUsed;
    inputModel.authenticationModel.isDefault = object.isDefault;
    state.mechanism = '?authMechanism=DEFAULT';
    state.tabAuth = object.tabAuth
    renderConnectionString();
  }

  function updateMechanismAuth(object: object) {
    state.mechanism = object.mechanism;
    inputModel.authenticationModel.isDefault = object.isDefault
    inputModel.authenticationModel.isSHA1 = object.isSHA1
    inputModel.authenticationModel.isSHA256 = object.isSHA256
    renderConnectionString();
  }

  function updateObjectProxy(object: object) {
    inputModel.inputServerModel.isUseProxy = object.isUsed
    inputModel.proxyModel.isWithPass = object.isWithPass
    inputModel.proxyModel.isWithIdentityFile = object.isWithIdentityFile
    inputModel.proxyModel.isSocks5 = object.isSocks5
    inputModel.proxyModel.hostName = object.hostName
    inputModel.proxyModel.port = object.port
    inputModel.proxyModel.sshUserName = object.sshUserName
    inputModel.proxyModel.sshPassword = object.sshPassword
  }

  function updateMethodProxy(object: object) {
    inputModel.inputServerModel.isUseProxy = object.isUsed
    inputModel.proxyModel.isWithPass = object.isWithPass
    inputModel.proxyModel.isWithIdentityFile = object.isWithIdentityFile
    inputModel.proxyModel.isSocks5 = object.isSocks5
  }

  function renderConnectionString() {
    if (inputModel.generalModel.isIncludeSrv) {
      state.srv = 'mongodb+srv'
    } else {
      state.srv = 'mongodb'
    }

    if (inputModel.generalModel.isDirectConnection) {
      state.direct = '&directConnection=true'
    } else {
      state.direct = ''
    }

    if (inputModel.authenticationModel.authDatabase.length == 0) {
      state.authSource = ''
    } else {
      state.authSource = `&authSource=${percentEncode(inputModel.authenticationModel.authDatabase)}`
    }
    
    if (inputModel.authenticationModel.username === null || inputModel.authenticationModel.password === null) {
      inputModel.authenticationModel.username = ''
      inputModel.authenticationModel.password = ''
    }

    if (inputModel.authenticationModel.username?.length > 0 || inputModel.authenticationModel.password?.length > 0) {
      state.auth = `${percentEncode(inputModel.authenticationModel.username)}`
      state.auth += inputModel.authenticationModel.password.length > 0 ? `:${percentEncode(inputModel.authenticationModel.password)}@` : `@`
    } else {
      state.auth = ''
    }
    console.log(inputModel.authenticationModel);
    
    state.connectionString = `${state.srv}://${state.auth}${inputModel.generalModel.host}/${state.mechanism}${state.direct}${state.authSource}`
  }

  async function fetchServers() {
    state.isServersLoading = true;
    const serverResponse = await axios.get('https://localhost:7176/Server')
    state.servers = serverResponse.data.responseData;
    state.isServersLoading = false;
  }

  async function fetchSever() {
    const serverResponse = await axios.get(`https://localhost:7176/Server/${state.serverFocused}`)
    inputModel.inputServerModel.name = serverResponse.data.responseData.name;
    inputModel.inputServerModel.isUseAuthentication = serverResponse.data.responseData.isUseAuthentication;
    inputModel.inputServerModel.isUseProxy = serverResponse.data.responseData.isUseProxy;
    inputModel.generalModel = serverResponse.data.responseData.general === null ? defaultInputModel.generalModel : serverResponse.data.responseData.general;
    inputModel.authenticationModel = serverResponse.data.responseData.isUseAuthentication === false ? defaultInputModel.authenticationModel : serverResponse.data.responseData.authentication;
    inputModel.proxyModel = serverResponse.data.responseData.isUseProxy === false ? defaultInputModel.proxyModel : serverResponse.data.responseData.proxy;
    inputModel.inputServerModel.id = serverResponse.data.responseData.id;
    renderConnectionString();
    console.log('can than', state);
    console.log('can than', inputModel);
    state.isServerInfoLoading = false;
  }

  async function getServerFocused(id: any) {
    state.isServerInfoLoading = true;
    state.serverFocused = id
    console.log("focused", id);
    await fetchSever()
  }

  async function handleClickSubmitBtn() {
    state.isLoading = true;
    if ('id' in inputModel.inputServerModel) {
      try {
        await axios
          .put("https://localhost:7176/Server",
            toRaw(inputModel)
          )
          .then(async (response) => {
            console.log(response);
            state.isLoading = false;
            await fetchServers()
            resetServerInfo();
          });
      } catch (error) {
        console.log(error);
      }
    } else {
      try {
        await axios
          .post("https://localhost:7176/Server/PostServer",
            toRaw(inputModel)
          )
          .then(async (response) => {
            console.log(response);
            state.isLoading = false;
            await fetchServers()
            resetServerInfo();
          });
      } catch (error) {
        console.log(error);
      }
    }
  }

  async function deleteServer() {
    state.isLoading = true;
    axios.delete(`https://localhost:7176/Server?id=${state.serverFocused}`)
        .then(async () => {
          console.log('server deleted');
          state.isLoading = false;
          await fetchServers()
          resetServerInfo();
        })
        .catch((error) => {
          console.error(error);
          // Handle any errors that occur during deletion of the project
        });
  }

  function setActiveTab(tabNumber: number) {
    activeTab.value = tabNumber;
  }


  onMounted(async () => {
    await fetchServers()
  })
</script>

<style lang="scss" scoped>
  @import '../assets/scss/library.scss';
</style>