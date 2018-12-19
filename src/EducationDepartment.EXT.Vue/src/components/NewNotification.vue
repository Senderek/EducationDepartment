<template>
  <div class="notification">
    <Alert v-if="alert" v-bind:message="alert" />
    

    <form style="margin-top:50px"   >
      <h1>Nowe powiadomienie</h1>
      <div class="form-group">
        <label for="subject">Temat</label>
        <input type="text" class="form-control"   placeholder="temat" v-model="notification.subject">
          </br>

          

            <label for="content">Treść</label>
            </br>
            <textarea class="form-control"  placeholder="Treść"  v-model="notification.content" rows="5"></textarea>
            </br>

          <div class="form-row">
            <div class="form-group col-md-6">
              <label for="autor">Adresat/Adresaci</label>
              <input type="text" class="form-control"   placeholder="adresaci" v-model="notification.destination">
          </div>
            <div class="form-group col-md-6">
              </br>
              <button @click="SendNotificationtoAll" type="button" class="btn btn-success mt-2">Do wszystkich</button>
            </div>
          </div>
    </div>

                    <button   class="btn btn-lg btn-primary btn-block">Wyślij powiadomienie</button>


                 

       
 
    </form>

  </div>
</template>

<script>
  import Alert from "./Alert"
  export default {
  name: "NewNotification",
  data() {
  return {
  notification: {},
  alert: ""
  }
  },
  methods: {
  SendNotificationtoAll(e) {
  if (
  !this.notification.subject ||
  !this.notification.content ||
  !this.notification.destination
  ) {
  this.alert = "Wypełnij wszystkie wymagane pola";

  } else
  {
  let newNotification = {
  notificationMessage: this.notification.content,
  notificationSubject: this.notification.subject

  }
  this.$http.post('https://localhost:44335/api/Notification/SendNotificationToAll', newNotification)
  .then(function(response){
  this.$router.push({path: '/', query: {alert: 'Konto utworzone'}});
  });

  e.preventDefault();
  }
  e.preventDefault();
  }
  },
  components: {
  Alert
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
