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
    <div class="row">
      <div class="col-6 mt-5" v-for="vault in vaults" :key="vault.id">
        <h2>Is this working?</h2>
        <h3>{{vault.name}}</h3>
        <h4>{{vault.description}}</h4>
        <button @click="deleteVault">Delete Vault</button>
      </div>
    </div>
  </div>
  <div v-for="vk in vaultKeeps" :key="vk._id" class="col-6">
    {{vk.name}} {{vk.description}}
  </div>
</div>
</template>

<script>
  export default {
    name: "dash",
    data() {
      return {
        vault: {
          name: "",
          description: "",
          userId: ""

        }
      }
    },
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    mounted() {
      this.$store.dispatch("getVaults")
    },
    methods: {
      logoutUser() {
        this.$store.dispatch("logout");
      },
      getHome() {
        this.$router.push({ name: "home" });
      },
      deleteVault(id) {
        this.$store.dispatch('deleteVault', id);
      },
      getVaults() {
        this.$store.dispatch('getVaults');
      },
      getVaultKeeps(vault) {
        this.$store.dispatch('getVaultKeeps', vault)
      },
      createVault() {
        this.vault.userId = this.vault.id
        this.$store.dispatch('createVault', this.vault);
        this.vault = { name: "", description: "", userId: "" }
      },
      // createVault() {
      //   this.$store.dispatch('createVault');
      // }
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
    }
  };
</script>
<style scoped>
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