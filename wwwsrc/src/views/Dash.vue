<template>
        <div class="dash container-fluid">
          
          <nav class="navbar navbar-expand-lg navbar-light bg-light">
            
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarText">
              <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                  <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                </li>
                <li button type="submit" class="btn btn-success" @click="logoutUser"><h5>Logout</h5></button>
                </li>
                <li class="nav-item active">
                  <a class="nav-link" href="#"></a>
                </li>
              </ul>
              <span class="navbar-text">
                <h3>Keepr</h3>
              </span>
            </div>
          </nav>
          <h2>{{user.name}}'s Dashboard</h2>
          
          
          <!-- <button type="submit" class="btn btn-success" @click="logoutUser"><h5>Logout</h5></button> -->
        </div>
      </template>
      
      <script>
        export default {
          name: "dash",
          mounted() {
            //blocks users not logged in
            if (!this.$store.state.user.id) {
              this.$router.push({ name: "login" });
            }
          },
          methods: {
            logoutUser() {
                      this.$store.dispatch("logout");
                  }
          },
            computed:{
                user() {
                    return this.$store.state.user;
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
      html {
        background-color:#163C00;
      }
      
      </style>