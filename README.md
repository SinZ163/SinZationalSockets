===============
	Usage
===============

SinZSockets socket = new SinZSockets(NetworkStream stream);

String username = socket.readString();
socket.writeString(username);
