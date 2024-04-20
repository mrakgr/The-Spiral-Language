from flask import Flask, current_app

app = Flask(__name__,static_url_path="")

@app.route("/")
def hello():
    return current_app.send_static_file("index.html")

if __name__ == "__main__":
    app.run(debug=True)
