from flask import Blueprint, current_app

main_page = Blueprint('main', __name__)

@main_page.route('/')
def index():
    return current_app.send_static_file("index.html")
