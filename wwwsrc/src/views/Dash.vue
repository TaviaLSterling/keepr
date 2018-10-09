<template>
        <div class="dash container-fluid">
          
          <nav class="navbar navbar-expand-lg navbar-light bg-light">
            
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarText">
              <ul class="navbar-nav mr-auto">
                <!-- <li class="nav-item active">
                  <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                </li> -->
                <li button type="submit" class="btn btn-warning mr-5" @click=""><h5>Home</h5></button>
                </li>
                <li button type="submit" class="btn btn-warning" @click="logoutUser"><h5>Logout</h5></button>
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
          <h2>{{user.username}}'s Dashboard</h2>
          <div>
              <form @submit.prevent="createVault">
                <h3>Create a Vault: </h3>
                  <input type="text" placeholder="Title">
                  <input type="text" placeholder="Description">
                  <button type="submit">Submit</button>
              </form>
              </div>
       
              <div class="VaultDetails">
                  <div class="row">
                      <!-- <h1>IS THIS WORKING?</h1> -->
                      <div class="col-6 mt-5" v-for="vault in vaults" :v-key="vault.id">
                          <h3>{{vault.name}}</h3>
                          <h4>{{vault.description}}</h4>
                          <button @click="deleteVault">Delete Vault</button>
                      </div>
                  </div>
              </div>
     
          
          
          <!-- <button type="submit" class="btn btn-success" @click="logoutUser"><h5>Logout</h5></button> -->
        </div>
      </template>
      
      <script>
        export default {
          data() {
      return {
        vault: {
          name: "",
          description: "",
          userId: ""

        }
      }
    },
          name: "dash",
          mounted() {
            //blocks users not logged in
            if (!this.$store.state.user.id) {
              this.$router.push({ name: "login" });
            }
              // this.$store.dispatch('getVaults');
            
          },
          methods: {
            logoutUser() {
                      this.$store.dispatch("logout");
                  },
            deleteVault(id) {
                this.$store.dispatch('deleteVault', id)
            },
            getVaults() {
              this.$store.dispatch('getVaults');
            },
            createVault() {
              this.$store.dispatch('createVault');
            }
          },
            computed:{
                user() {
                    return this.$store.state.user;
                },
                vaults() {
                return this.$store.state.vaults;
            }
            }
        };
      </script>
      <style scoped>
      h1, h2 {
        /* margin-top: 5rem; */
        font-size:100px;
        color:white;
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
        background-color:#163C00;
        height: 100vh;
      }
      html, .dash {
        background-color:#163C00;
        color: white;
        font-family: 'Oregano', cursive;
      }
      .tinyImg {
  height:45px;
  width:45px;
}
.vaultDetails {
  color:white;
  font-family: 'Oregano', cursive;
}
      
      </style>