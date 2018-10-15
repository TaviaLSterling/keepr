<template>
  <div class="dash container-fluid">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText"
      aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <li button type="submit" class="btn btn-warning mr-5" @click="getHome">
          <h5>Home</h5></button>
        </li>
        <li button type="submit" class="btn btn-warning" @click="logoutUser">
          <h5>Logout</h5></button>
        </li>
      </ul>
      <span class="navbar-text">
        <img class="tinyImg" src="../assets/pig-icon-7.png">
        <h3>Keepr</h3>
      </span>
    </div>
  </nav>
  <h2>{{user.username}}'s Dashboard</h2>
  <div>
    <form @submit.prevent="createVault">
      <h3>Create a Vault: </h3>
      <input type="text" placeholder="Title" v-model="vault.name">
      <input type="text" placeholder="Description" v-model="vault.description">
      <button type="submit">Submit</button>
    </form>
  </div>
  <div class="vaultDetails">
    <h3>{{user.username}}'s Vaults</h3>
    <div class="row">
      <div class="col-6 mt-5" v-for="vault in vaults" :key="vault.id">
        <h3>{{vault.name}}</h3>
        <h4>{{vault.description}}</h4>
        <button class="btn btn-info mr-2" @click="editVault(vault.id)">Edit</button>
        <button class="btn btn-danger" @click="deleteVault(vault.id)">Delete Vault</button>
      </div>
    </div>
  </div>
  
  
  <h3>{{user.username}}'s Keeps</h3>
  <KeepDetails />
  <div>
    <h3>{{user.username}}'s Vault Keeps</h3>
      <form @submit.prevent>
        <select v-model="pickVault">
          <option diabled value="">Vaults</option>
          <option v-for="vault in vaults" v-bind:value="vault.id">{{vault.name}}</option>
        </select>
        <button class="btn btn-success" type="submit" @click="getVaultKeeps(pickVault)">View</button>
      </form>
    </div>
  <div v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id" class="col-8">
    <img :src="vaultKeep.img">
      <div>
        <h3> {{vaultKeep.name}}</h3>
      </div>
    <button type="button" class="btn btn-danger" @click="deleteVaultKeep(vaultKeep.id)">Delete</button>
  </div>
</div>
</template>

<script>
   import KeepDetails from '../components/KeepDetails'
  export default {
    name: "dash",
    data() {
      return {
        keep: {
          name:"",
          description:"",
          img:"",
          userId:""
        },
        vault: {
          name: "",
          description: "",
          userId: ""
        },
        vaultKeep: {
          vaultId: "",
          keepId: "",
          userId: ""
        },
        pickVault: ""
      }
    },
    props: ["KeepDetails"],
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    mounted() {
      this.$store.dispatch("getVaults")
      // this.$store.dispatch("getVaultKeeps")
    },
    methods: {
      logoutUser() {
        this.$store.dispatch("logout");
      },
      getHome() {
        this.$router.push({ name: "home" });
      },
      editVault() {
        this.$store.dispatch("editVault")
      },
      deleteVault(id) {
        this.$store.dispatch('deleteVault', id);
      },
      deleteVaultKeep(keepId) {
        this.$store.dispatch("deleteVaultKeep", { keepId: keepId, vaultId: this.pickVault })
      },
      getVaults() {
        this.$store.dispatch('getVaults');
      },
      getVaultKeeps(vault) {
        this.$store.dispatch('getVaultKeeps', vault)
      },
      createVault() {
        this.vault.userId = this.user.id
        this.$store.dispatch('createVault', this.vault);
        this.vault = { name: "", description: "", userId: "" }
      },
      savedVaultKeep(keep) {
        keep.keeps++
        this.vaultKeep.userId = this.user.id
        this.vaultKeep.keepId = keep.id
        this.vaultKeep.vaultId = this.pickVault
        this.$store.dispatch("savedVaultKeep", this.vaultKeep);
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      vaults() {
        return this.$store.state.vaults;
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps;
      },
      keeps() {
        return this.$store.state.keeps;
      },
      usersKeeps() {
        return this.$store.state.userKeeps;
      }
    },
    components: {
      KeepDetails
    }
  };
</script>
<style scoped>
  form {
    margin-bottom:30px;
  }
  h1,
  h2 {
    /* margin-top: 5rem; */
    font-size: 100px;
    color: white;
    font-family: 'Oregano', cursive;
    background-color: #4C8302;

  }

  .navbar {
    font-family: 'Oregano', cursive;
  }

  h5 {
    color: white;
    font-family: 'Oregano', cursive;
  }

  .home {
    background-color: #163C00;
    height: 100vh;
  }

  html,
  .dash {
    background-color: #163C00;
    color: white;
    font-family: 'Oregano', cursive;
  }

  .tinyImg {
    height: 45px;
    width: 45px;
  }

  .vaultDetails {
    color: white;
    font-family: 'Oregano', cursive;
  }
</style>