<template>
  <div class="home container-fluid">
    
    <nav class="navbar navbar-expand-lg">
        <!-- navbar-light bg-light -->
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarText">
        <ul class="navbar-nav mr-auto">
          <!-- <li class="nav-item active">
            <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
          </li> -->
          <li button type="submit" class="btn btn-warning mr-5" @click="logoutUser"><h5>Logout</h5></button>
          </li>
          <li button type="submit" class="btn btn-warning" @click="getDash"><h5>Dashboard</h5></button>
          </li>
          <li class="nav-item active">
            <a class="nav-link" href="#"></a>
          </li>
        </ul>
        <span class="navbar-text">
          <img class="tinyImg" src="../assets/pig-icon-7.png">
          <h3>Keepr</h3>
        </span>
      </div>
    </nav>
    <h1>Welcome to Keepr</h1>
    <!-- <div>
        <form @submit.prevent="createVault">
          <h3>Create a Vault: </h3>
            <input type="text" placeholder="Title" v-model="vault.name">
            <input type="text" placeholder="Description" v-model="vault.description">
            <button type="submit">Submit</button>
        </form>
        </div> -->
    <div>
    <form @submit.prevent="createKeep">
      <h3>Create a Keep: </h3>
        <input type="text" placeholder="Title" v-model="keep.name">
        <input type="text" placeholder="Description" v-model="keep.description">
        <input type="text" placeholder="Image Url" v-model="keep.img">
        <button type="submit">Submit</button>
    </form>
    </div>
    <!-- <div v-for="keep in keeps" :key="keep.id">
        <h1>{{Keep.name}}</h1>
        <img :src="keep.img">
        <h4>Description:{{keep.description}}</h4>
        <h4>Views: {{keep.views}}</h4>
        <img :src="keep.image">
        <button v-if="user.id == keep.userId" class="btn btn-danger" @click="deleteKeep(keep.id)">Delete</button>
    </div> -->
  
    <KeepDetails />
    
    <!-- <button type="submit" class="btn btn-success" @click="logoutUser"><h5>Logout</h5></button> -->
  </div>
</template>

<script>
  import KeepDetails from '../components/KeepDetails'
  export default {
    data() {
      return {
        keep: {
          name: "",
          description: "",
          img: "",
          userId:""
        },
        vault: {
          name:"",
          description:"",
          userId:""
        }
      }
    },
    name: "home",
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
        // this.$store.dispatch("getKeeps");
      }
      this.$store.dispatch("getKeeps");
    },
    props: ["KeepDetails"],
    methods: {
      logoutUser() {
                this.$store.dispatch("logout");
            },
    getDash() {
      this.$store.dispatch("getDash");
      this.$router.push({ name: "dash" });
    },
    createKeep() {
      this.keep.userId = this.user.id
      this.$store.dispatch('createKeep',this.keep);
      this.keep = {name:"",description:"",img:"",userId:""}
    },
    createVault() {
      this.vault.userId = this.vault.id
      this.$store.dispatch('createVault',this.vault);
      this.vault = {name:"",description:"",userId:""}
    },
    getKeeps() {
      this.$store.dispatch('setKeeps')
    },
    createVault() {
      this.$store.dispatch('getVaults')
    },
    deleteKeep() {
      this.$store.dispatch('deleteKeep')
    }
    },
    computed: {
      keeps() {
                return this.$store.state.keeps;
            },
            user(){
              return this.$store.state.user;
            },
            vaults() {
              return this.$store.state.vaults;
            }
    },
    components: {
      KeepDetails
    }
  };
</script>
<style scoped>
h1 {
  /* margin-top: 5rem; */
  font-size:100px;
  color: #4C8302;
  font-family: 'Oregano', cursive;
  
}
.navbar {
  background-color: #4C8302;
  font-family: 'Oregano', cursive;
}
h5, h3 {
    color: white;
  font-family: 'Oregano', cursive;
}
.home {
  background-color:#163C00;
  height: 100vh;
}
html {
  background-color:#163C00;
}
.tinyImg {
  height:45px;
  width:45px;
}

</style>